
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class pauseMenuButtts : MonoBehaviour
{
    //public TextMeshProUGUI op;
    public GameObject PauseWindow;
    public AudioMixer audioMixer;
    public static pauseMenuButtts Current;
    public Button Pause;
    public Slider VolumeSLider;

    public TMP_Dropdown QualityDroDown;
    private void Start()
    {

        VolumeSLider.value = AudioManager.MusicVol;
        QualityDroDown.value = AudioManager.QualiNo;
        InputFromDropdown(AudioManager.QualiNo);
        setVolumeToGame(AudioManager.MusicVol);
        Pause.interactable = true;
        Time.timeScale = 1f;
        //SettingsWindow.SetActive(false);
        PauseWindow.SetActive(false);
    }
    public void quitheGame()
    {
        FindObjectOfType<AudioManager>().Plays("Select");
        Application.Quit();
    }

    public void OpenPauseWindow()
    {
        Pause.interactable = false;
        FindObjectOfType<AudioManager>().Plays("Select");
        Time.timeScale = 0f;
        PauseWindow.SetActive(true);
        FindObjectOfType<GAMEMANAGER>().MakeBallInactive();///////
    }
    public void OpenLevelWindow()
    {
       
        FindObjectOfType<AudioManager>().Plays("Select");
        FindObjectOfType<GAMEMANAGER>().StopTheSoundBoi();//current inp

        Time.timeScale = 1f;
        GameStartManager.Normal = true;
        SceneManager.LoadScene("homemenu");
    }
    public void ResumeTheGame()
    {
        FindObjectOfType<AudioManager>().Plays("Select");
        Time.timeScale = 1f;
        PauseWindow.SetActive(false);
        Pause.interactable = true;
        FindObjectOfType<GAMEMANAGER>().MakeBallActive();/////////
    }
    public void InputFromDropdown(int Val)
    {
        //  AudioManager.QualiNo = Val;
        FindObjectOfType<AudioManager>().Plays("Select");
        QualitySettings.SetQualityLevel(Val);
        if (Val != AudioManager.QualiNo)
        {
            PlayerPrefs.SetInt("Quality", Val);
            AudioManager.QualiNo = Val;
        }

    }
    public void setVolumeToGame(float svalue)
    {
        //  AudioManager.MusicVol = svalue;
        //FindObjectOfType<AudioManager>().Plays("Select");
        audioMixer.SetFloat("volume", svalue);
        if (svalue != AudioManager.MusicVol)
        {
            PlayerPrefs.SetFloat("MusicVolume", svalue);
            AudioManager.MusicVol = svalue;
        }
    }
}
