using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
 public void OnPlayButton()
 {
    SceneManager.LoadScene(1);
 }   

 public void onQuitButton()
 {
    Application.Quit();
 }
}
