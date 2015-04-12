using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public enum MessageType { intro, win, scrap, artifact }

public class MessageManager : MonoBehaviour
{

    public Image currentImage;
    public int currentIndex;
    public Text currentText;
    public GameObject canvas;

    private List<Sprite> sprites;
    private List<string> texts;
    bool messageInProgress = false;

    public Sprite female;
    public Sprite male;
    public Sprite help;

    public List<MessageType> usedTypes = new List<MessageType>();


    // Use this for initialization
    void Start()
    {
        GlobalSettings.messageManager = this;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (messageInProgress && Input.GetKeyDown(KeyCode.Return))
        {
            NextText();
        }
    }

    void NextText()
    {
        currentIndex++;
        if (currentIndex > texts.Count - 1)
        {
            messageInProgress = false;
            GlobalSettings.TogglePause(false);
            canvas.SetActive(false);
        }
        else
        {
            currentText.text = texts[currentIndex];
            currentImage.sprite = sprites[currentIndex];
        }
    }

    public void SendMessage(MessageType messageType)
    {
        if (!usedTypes.Contains(messageType))
        {
            usedTypes.Add(messageType);
            GlobalSettings.TogglePause(true);
            currentIndex = -1;
            messageInProgress = true;
            canvas.SetActive(true);

            switch (messageType)
            {
                case MessageType.intro:
                    texts = new List<string>() {"*HELP* Press enter to proceed.",
                    "Jackson: \"HQ, I've arrived at the anomaly.\"",
                    "HQ: \"Greetings commander, well done. Begin extraction of artifacts immediately.\"",
                    "Jackson: \"There's a problem, I'm detecting high amounts of space distortion. I may need to improve the shield capacity of my vessel.\"",
                    "HQ: \"Affirmative. Use of deep space automation facility approved.\"",
                    "Jackson: \"I'm going to need resources, maybe there's some useful materials inside the anomaly. Wish me luck HQ, I'm going in.\"",
                    "HQ: \"Affirmative.\"",
                    "HQ: \"... And Jackson?\"",
                    "Jackson: \"Yeah?\"",
                    "HQ: \"Be careful.\"",
                    "Jackson: \"I will, Alice. Jackson out.\""};
                    sprites = new List<Sprite>() {help, male, female, male, female, male, female, female, male, female, male};
                    break;
                case MessageType.win:
                    texts = new List<string>() {"HQ: \"Jackson?\"",
                    "HQ: \"...\"",
                    "HQ: \"Jackson, please respond.\""};
                    sprites = new List<Sprite>() { female, female, female};
                    break;

                case MessageType.artifact:
                    texts = new List<string>() {"Jackson: \"HQ, I've found something. Sending analysis.\"",
                    "HQ: \"Jackson, that's incredible! Take this back to the facility, we might be able to use this for something.\"",
                    "*HELP* Artifacts are used for unlocking special upgrades, take it back the the facility to research it."};
                    sprites = new List<Sprite>() { male, female, help};
                    break;

                case MessageType.scrap:
                    texts = new List<string>() {"Jackson: \"There, some scrap. Alright, gotta take this back to the facility and upgrade my ship.\"",
                    "*HELP* Scrap is used for upgrading your ship, take it to the facility to refine it into materials."};
                    sprites = new List<Sprite>() {male, help};
                    break;
                default:
                    break;
            }

            NextText();
        }


    }


}
