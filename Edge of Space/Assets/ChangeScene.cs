using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
   public void Change(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}