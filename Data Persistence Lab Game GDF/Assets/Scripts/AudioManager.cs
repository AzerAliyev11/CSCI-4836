using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [SerializeField] Slider volumeSlider;
    float volume;

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", volumeSlider.value);
        
        volumeSlider.value = volume;
        music.volume = volume;
        sfx.volume = volume;
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);

        music.volume = volume;
        sfx.volume = volume;

        Debug.Log(music.volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.pitch = Random.Range(0.9f, 1.1f);
        sfx.PlayOneShot(clip);
    }
}
