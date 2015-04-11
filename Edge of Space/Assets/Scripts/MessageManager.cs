using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum MessageType { intro, win }

public class MessageManager : MonoBehaviour
{

    public Sprite currentImage;
    public string currentText;

    public MessageScript messageScript;
    public Sprite female;
    public Sprite male;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendMessage(MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.intro:
                currentImage = female;
                currentText = "";
                break;
            case MessageType.win:
                currentImage = male;
                currentText = "";
                break;
            default:
                break;
        }
    }


}
