

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GAMEMANAGER : MonoBehaviour
{

    public static GAMEMANAGER instance;
    public string[] nameofSoundstoPlay;
    string temp;
    public GameObject LevelButtonInModes, GetBackBanner, levelsDeath, warningBox, DeathScreen, winscreeen, HardcoreDeathScreen,currBall;
    // public Scene[] GameScene;
    public TextMeshProUGUI HardCoreScore;
    public GameObject LEftMovBut, rightMovBut, ClockRotBut, AntiCloBut;



    private void Awake()
    {
     
    }
    private void Start()
    {
       LEftMovBut.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("LeftX", -284f), PlayerPrefs.GetFloat("LeftY", -467.02f), 0f);
        //Right
       rightMovBut.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("RightX", -80f), PlayerPrefs.GetFloat("RightY", -467.02f), 0f);
        //     //Clock Wise 
        ClockRotBut.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("ClockX", 287.38f), PlayerPrefs.GetFloat("ClockY", -583f), 0f);
        //ANticlockWise
        AntiCloBut.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("AntiX", 287.38f), PlayerPrefs.GetFloat("AntiY", -401.99f), 0f);

        LEftMovBut.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleLeft", 1.35f), PlayerPrefs.GetFloat("ScaleLeft", 1.35f),
                                                                               PlayerPrefs.GetFloat("ScaleLeft", 1.35f));
        rightMovBut.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleRight", 1.35f), PlayerPrefs.GetFloat("ScaleRight", 1.35f),
                                                                               PlayerPrefs.GetFloat("ScaleRight", 1.35f));
        ClockRotBut.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleClock", 1.35f), PlayerPrefs.GetFloat("ScaleClock", 1.35f),
                                                                              PlayerPrefs.GetFloat("ScaleClock", 1.35f));
        AntiCloBut.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f), PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f),
                                                                              PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f));

        winscreeen.SetActive(false);
        int k;
        k = Random.Range(0, nameofSoundstoPlay.Length);
        temp = nameofSoundstoPlay[k];
        FindObjectOfType<AudioManager>().Plays(temp);
        if (GameStartManager.Normal)
        {
            levelsDeath.SetActive(true);
            LevelButtonInModes.SetActive(true);
            GetBackBanner.SetActive(false);
          //  PauseButtonHardCoreMode.SetActive(false);

        }
        else if (GameStartManager.Hardcore)
        {
            levelsDeath.SetActive(false);
           LevelButtonInModes.SetActive(false);
            GetBackBanner.SetActive(true);
          //  PauseButtonHardCoreMode.SetActive(true);
        }

    }
    public void StopTheSoundBoi()
    {
        FindObjectOfType<AudioManager>().stopPlaying(temp);
    }

    public void levelrestart()
    {
        if (GameStartManager.Normal)
        {

            FindObjectOfType<AudioManager>().stopPlaying(temp);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (GameStartManager.Hardcore)
        {
            FindObjectOfType<AudioManager>().stopPlaying(temp);
            SceneManager.LoadScene(1);
        }
    }

    public void Newlevel()
    {//incease player prefs;
        //if buildindex+1  is greater than player prefs then increment player prefs 
        if (GameStartManager.Normal)
        {
            int tempNo = PlayerPrefs.GetInt("LevlReached");
            if (tempNo < SceneManager.GetActiveScene().buildIndex + 1)
            {

                PlayerPrefs.SetInt("LevlReached", SceneManager.GetActiveScene().buildIndex + 1);
            }
            FindObjectOfType<AudioManager>().stopPlaying(temp);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (GameStartManager.Hardcore)
        {
            int cureentHighs = PlayerPrefs.GetInt("HardcoreHighScore");
            if(cureentHighs<SceneManager.GetActiveScene().buildIndex+1)
            {
                PlayerPrefs.SetInt("HardcoreHighScore", SceneManager.GetActiveScene().buildIndex + 1);
            }
            FindObjectOfType<AudioManager>().stopPlaying(temp);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void NewNoSetIfWin()
    {
        if (GameStartManager.Normal)
        {
            int tempNo = PlayerPrefs.GetInt("LevlReached");
            if (tempNo < SceneManager.GetActiveScene().buildIndex + 1)
            {

                PlayerPrefs.SetInt("LevlReached", SceneManager.GetActiveScene().buildIndex + 1);
            }
            FindObjectOfType<AudioManager>().stopPlaying(temp);
         //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (GameStartManager.Hardcore)
        {
            int cureentHighs = PlayerPrefs.GetInt("HardcoreHighScore");
            if (cureentHighs < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("HardcoreHighScore", SceneManager.GetActiveScene().buildIndex + 1);
            }
            FindObjectOfType<AudioManager>().stopPlaying(temp);
          //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void Update()
    {

    }

    public void LevelRestartFromDeath()
    {
        if((SceneManager.GetActiveScene().buildIndex+1) <= PlayerPrefs.GetInt("LevlReached"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            DeathScreen.SetActive(false);
           // FindObjectOfType<baBehaviour>().DeathScreens.SetActive(false);
            warningBox.SetActive(true);
        }
    }
    public void CloseWarningBox()
    {
        DeathScreen.SetActive(true);
        warningBox.SetActive(false);
      //  FindObjectOfType<baBehaviour>().DeathScreens.SetActive(true);
    }
    public void BallLavaTouch()
    {
        if (GameStartManager.Normal)
        {
            FindObjectOfType<AudioManager>().stopPlaying(temp);
            HardcoreDeathScreen.SetActive(false);
            DeathScreen.SetActive(true);
        }else if(GameStartManager.Hardcore)
        {
            FindObjectOfType<AudioManager>().stopPlaying(temp);
            DeathScreen.SetActive(false);
            HardCoreScore.text = SceneManager.GetActiveScene().buildIndex.ToString();
            HardcoreDeathScreen.SetActive(true);
        }

       
    }
    
    public void GoHome()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().stopPlaying(temp);
        FindObjectOfType<AudioManager>().Plays("Theme");
        SceneManager.LoadScene(0);
    }
    public void NExtLevelWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HardcoreRestartGame()
    {
        FindObjectOfType<AudioManager>().stopPlaying(temp);
        GameStartManager.Hardcore = true;
        GameStartManager.Normal = false;
        SceneManager.LoadScene(1);
    }
    public void MakeBallInactive()
    {
       currBall.SetActive(false);
    }
    public void MakeBallActive()
    {
        currBall.SetActive(true);
    }
    public void GetmeBackhome()
    {
        SceneManager.LoadScene(0);
    }
}
