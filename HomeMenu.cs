using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
     //Load Scene
   public void PlayButton()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   //Quit Game
   public void QuitGame()
   {
     Application.Quit();
     Debug.Log("Player has quit the game");
   }
}
