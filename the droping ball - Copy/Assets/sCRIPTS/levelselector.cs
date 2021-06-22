using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselector : MonoBehaviour
{
    public Button[] LevelButton;
    public int lastlevelComplete;
    private void Start()
    {
        lastlevelComplete = PlayerPrefs.GetInt("LevlReached",1);
        for (int i = 0; i < LevelButton.Length; i++)
        {
            if (lastlevelComplete <  i + 1)
            {
                LevelButton[i].interactable = false;
            }
        }
    }
    public void LOadingLevels(string nameOftheLevel)
    {
        FindObjectOfType<AudioManager>().Plays("Select");
        FindObjectOfType<AudioManager>().stopPlaying("Theme");
        SceneManager.LoadScene(nameOftheLevel);
        
    }
   // IEnumerator

}
