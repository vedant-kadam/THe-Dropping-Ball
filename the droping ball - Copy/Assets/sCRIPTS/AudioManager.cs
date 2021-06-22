using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public sounds[] Sound;
    public static AudioManager instance;
    public AudioMixerGroup audioMixer1; 
    public static float MusicVol=-12f;
    public static int QualiNo=2;

    private void Awake()
    {
       
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
            
        }
        foreach(sounds s in Sound)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loops;
            s.source.outputAudioMixerGroup = audioMixer1;
        }
        DontDestroyOnLoad(gameObject);
        // Play(Theme);
        //  Playss(Theme);
      
    }
    private void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume",-17);
        PlayerPrefs.SetInt("Quality",2);
        MusicVol = PlayerPrefs.GetFloat("MusicVolume");
        QualiNo = PlayerPrefs.GetInt("Quality");
        Plays("Theme");
    }
    public void Plays(string name)
    {
       foreach(sounds s in Sound)
        {
            if(s.Name == name)
            {
                s.source.Play();
            }
            
        }
      
    }
    public void stopPlaying(string nameofthesound)
    {
        foreach (sounds s in Sound)
        {
            if (s.Name == nameofthesound)
            {
                s.source.Stop();
            }

        }

    }
}
