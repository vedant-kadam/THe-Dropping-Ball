using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastlevelShit : MonoBehaviour
{
    public GameObject LevelBall;
    public GameObject pannlScreen;
    // Start is called before the first frame update
    void Start()
    {
        LevelBall.SetActive(false);
        pannlScreen.SetActive(true);
        Time.timeScale = 0f;
        
    }

    // Update is called once per frame
   public void StrtThelastLevel()
    {
        Time.timeScale = 1f;
        pannlScreen.SetActive(false);
        LevelBall.SetActive(true);

    }
}
