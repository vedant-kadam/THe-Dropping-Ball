
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class GameStartManager : MonoBehaviour
{
    public GameObject StartSign, Mode, NormalLevels,resetWindow,resetButton,Credits,c1,c2,c3,c4,c5,Firstone,settingsWindows,EditorWindows,tutorials;
  //  public GameObject sb, qb,  cw,hdhs,rw;
    public static bool Normal, Hardcore;
    string name_of_sound="Select";
    public ParticleSystem startting;
    public TextMeshProUGUI NumberOfLevels;
    public TMP_Dropdown Start_Derop;
    public Slider Start_Slider_Music;
    public AudioMixer AudioMix_Start;
   // public GameObject BackGround;
   // public static GameStartManager instance;
    private void Start()
    {
        Start_Slider_Music.value = PlayerPrefs.GetFloat("MusicVolume");
        Start_Derop.value = PlayerPrefs.GetInt("Quality");
        int currentHighSciore = PlayerPrefs.GetInt("HardcoreHighScore", 1);
        NumberOfLevels.text = currentHighSciore.ToString();
        InputFromDropdown_start(AudioManager.QualiNo);
        //  DontDestroyOnLoad(gameObject);
        setVolumeToGame_start(AudioManager.MusicVol);

        FindObjectOfType<AudioManager>().Plays("Theme");
        Normal = Hardcore = false;
        startting.Play();
    }
    
    public void ClickOnStart()
    {
        playSelectsound();
        StartSign.SetActive(false);
        Mode.SetActive(true);
        
       
      //  rb.SetActive(false);
        // BackGround.SetActive(false);
    }
    public void clickOnNormal()
    {
        playSelectsound();
        StartSign.SetActive(false);
        Mode.SetActive(false);
        NormalLevels.SetActive(true);
        Normal = true;
        Hardcore = false;
       
       
      //  rb.SetActive(true);
    }
    public void ClickOnHardcore()
    {
        playSelectsound();
        Normal = false;
        Hardcore = true;
        SceneManager.LoadScene(1);
        //load the hardcore scean;

    }
    public void Reseting()
    {
        playSelectsound();
        resetWindow.SetActive(true);
    }
    public void ResetWindowYes()
    {
        playSelectsound();
        PlayerPrefs.DeleteAll();
        resetWindow.SetActive(false);
        SceneManager.LoadScene(0);

    }
    public void resetWindowNo()
    {
        playSelectsound();
        resetWindow.SetActive(false);
    }
    public void backFormLevel()
    {
       
     //   rb.SetActive(false);
        playSelectsound();
        NormalLevels.SetActive(false);
        Mode.SetActive(true);
    }
    void playSelectsound()
    {
        FindObjectOfType<AudioManager>().Plays(name_of_sound);
    }
   public void backtostart()
    {
        
       
       // rb.SetActive(false);
        // BackGround.SetActive(true);
        playSelectsound();
        StartSign.SetActive(true);
        Mode.SetActive(false);
    }
    public void quitbro()
    {
        Application.Quit();
    }
    public void ResttingOnStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void CreditsSection()
    {
        StartSign.SetActive(false);
        playSelectsound();
        Credits.SetActive(true);
    }
    public void InputFromDropdown_start(int val1)
    {
        //  AudioManager.QualiNo = Val;
      //  FindObjectOfType<AudioManager>().Plays("Select");
        QualitySettings.SetQualityLevel(val1);
        if (val1 != AudioManager.QualiNo)
        {
            PlayerPrefs.SetInt("Quality", val1);
            AudioManager.QualiNo = val1;
        }

    }
    public void setVolumeToGame_start(float svalue1)
    {
        //  AudioManager.MusicVol = svalue;
        //FindObjectOfType<AudioManager>().Plays("Select");
        AudioMix_Start.SetFloat("volume", svalue1);
        if (svalue1 != AudioManager.MusicVol)
        {
            PlayerPrefs.SetFloat("MusicVolume", svalue1);
            AudioManager.MusicVol = svalue1;
        }
    }

    public void Creditsection1()
    {
        playSelectsound();
        c1.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);
        c5.SetActive(false);

    }
    public void CreditSection2()
    {
        playSelectsound();
        c1.SetActive(false);
        c2.SetActive(true);
        c3.SetActive(false);
        c4.SetActive(false);
        c5.SetActive(false);
    }
    public void Creditsection3()
    {
        playSelectsound();
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(true);
        c4.SetActive(false);
        c5.SetActive(false);
    }
    public void CreditSection4()
    {
        playSelectsound();
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(true);
        c5.SetActive(false);
    }
    public void CreditSection5()
    {
        playSelectsound();
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);
        c5.SetActive(true);
    }

    public void BackToStatrtFromCreditSection()
    {
        StartSign.SetActive(true);
        playSelectsound();
        Credits.SetActive(false);
    }
    public void Start_sign_on()
    {
        StartSign.SetActive(true);
        Firstone.SetActive(false);
    }
    public void OpenSettingsWindow()
    {
        settingsWindows.SetActive(true);
        StartSign.SetActive(false);
        playSelectsound();
    }
    public void CloseSettingsWindow()
    {
        StartSign.SetActive(true);
        settingsWindows.SetActive(false);
        playSelectsound();
        
    }
    public void OpenEditorsWindow()
    {
        EditorWindows.SetActive(true);
        settingsWindows.SetActive(false);
        playSelectsound();
    }
    public void closeEditorssindow()
    {
        EditorWindows.SetActive(false);
        settingsWindows.SetActive(true);
        playSelectsound();
    }
    public void ExitTutorial()
    {
        tutorials.SetActive(false);
        EditorWindows.SetActive(true);
        playSelectsound();
    }
    public void EnterTutorial()
    {
        playSelectsound();
        tutorials.SetActive(true);
        EditorWindows.SetActive(false);
    }
        
}
