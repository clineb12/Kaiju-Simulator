using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public Slider _musicSlider, _sfxSlider;
    public float musicVolume, sfxVolume;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Instance.PlayMusic("BGM");
    }

    private void Update()
    {
        musicSource.volume = _musicSlider.value;
        sfxSource.volume = _sfxSlider.value;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.mute == false)
        {
            musicVolume = _musicSlider.value;
        }
        musicSource.mute = !musicSource.mute;
        if (musicSource.mute == false)
        {
            _musicSlider.value = musicVolume;
        }
        else
        {
            _musicSlider.value = 0;
        }

    }

    public void ToggleSFX()
    {
        if (sfxSource.mute == false)
        {
            sfxVolume = _sfxSlider.value;
        }
        sfxSource.mute = !sfxSource.mute;
        if (sfxSource.mute == false)
        {
            _sfxSlider.value = sfxVolume;
        }
        else
        {
            _sfxSlider.value = 0;
        }
    }

}