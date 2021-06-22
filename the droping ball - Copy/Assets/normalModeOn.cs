using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class normalModeOn : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
      //  FindObjectOfType<AudioManager>().Plays("Theme");
        GameStartManager.Normal = true;
        FindObjectOfType<AudioManager>().Plays("LevelTheme1");
        
    }
   public void GoHome()
    {
        FindObjectOfType<AudioManager>().stopPlaying("LevelTheme1");
        SceneManager.LoadScene(0);
    }
 
}
