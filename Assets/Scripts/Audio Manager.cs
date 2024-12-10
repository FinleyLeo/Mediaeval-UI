using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] SFXSound, musicSounds;
    public AudioSource SFXSource, musicSource;

    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVol"))
        {
            musicMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("musicVol")) * 20);
        }

        else
        {
            musicMixer.SetFloat("MusicVol", 0);
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            SFXMixer.SetFloat("SFXVol", Mathf.Log10(PlayerPrefs.GetFloat("sfxVol")) * 20);
        }

        else
        {
            SFXMixer.SetFloat("SFXVol", 0);
        }

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            PlayMusic("MenuMusic");
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);

        if (s == null)
        {
            print("music not found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void MusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVol", volume);
        musicMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSound, x => x.soundName == name);

        if (s == null)
        {
            print("sound not found");
        }

        else
        {
            SFXSource.PlayOneShot(s.clip);
        }
    }

    public void SFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxVol", volume);
        SFXMixer.SetFloat("SFXVol", Mathf.Log10(volume) * 20);
    }
}
