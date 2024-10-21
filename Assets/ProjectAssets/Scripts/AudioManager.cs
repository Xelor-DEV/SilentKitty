using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [BoxGroup("Audio Mixer Settings")]
    [SerializeField, Required] private AudioMixer audioMixer;

    [BoxGroup("Audio Sources")]
    [SerializeField, Required] private AudioSource musicAudioSource;

    [BoxGroup("Audio Sources")]
    [SerializeField, Required] private AudioSource sfxAudioSource;

    [BoxGroup("Audio Clips")]
    [ReorderableList]
    [SerializeField] private AudioClip[] musicClips;

    [BoxGroup("Audio Clips")]
    [ReorderableList]
    [SerializeField] private AudioClip[] sfxClips;

    [BoxGroup("Audio Configuration")]
    [Expandable]
    [SerializeField] private AudioConfig audioConfig;

    [BoxGroup("Fade Settings")]
    [Range(0.1f, 5.0f)]
    [SerializeField, Tooltip("Duración del fade de música en segundos")]
    private float fadeDuration = 1.0f;

    private Stack<AudioSource> sfxSourceStack = new Stack<AudioSource>();

    [BoxGroup("Fade Settings")]
    [ReadOnly] 
    [SerializeField] private bool isFading = false;

    public AudioConfig AudioConfig
    {
        get
        {
            return audioConfig;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Configuración de volúmenes
    public void SetVolumeOfMusic(Slider musicConfiguration)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicConfiguration.value) * 20f);
    }

    public void SetVolumeOfSfx(Slider sfxConfiguration)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxConfiguration.value) * 20f);
    }

    public void SetVolumeOfMaster(Slider masterConfiguration)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterConfiguration.value) * 20f);
    }

    // Reproducir música sin transición
    public void PlayMusic(int index)
    {
        // No permitir cambio de música si hay un fade en curso
        if (isFading == false)
        {
            musicAudioSource.Stop();
            musicAudioSource.clip = musicClips[index];
            musicAudioSource.Play();
        }

    }

    // Reproducir música con transición (fade out)
    public void PlayMusicWithTransition(int index)
    {
        if (isFading == false)
        {
            StartCoroutine(FadeOutMusicAndPlayNew(index));
        }
    }

    private IEnumerator FadeOutMusicAndPlayNew(int newMusicIndex)
    {
        isFading = true; // Se esta marcando que se inicio el fade

        // Realizar el fade out
        float currentVolume;
        audioMixer.GetFloat("MusicVolume", out currentVolume);
        float startVolume = Mathf.Pow(10f, currentVolume / 20f); // Convertir dB a valor lineal

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Lerp(startVolume, 0f, normalizedTime)) * 20f);
            yield return null;
        }

        // Parar la música anterior y reproducir la nueva
        musicAudioSource.Stop();
        musicAudioSource.clip = musicClips[newMusicIndex];
        musicAudioSource.Play();

        // Realizar fade in de la nueva música
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Lerp(0f, startVolume, normalizedTime)) * 20f);
            yield return null;
        }

        isFading = false; // El fade ha terminado
    }

    // Reproducir SFX usando la pila de AudioSource
    public void PlaySfx(int index)
    {
        if (sfxAudioSource.isPlaying == true)
        {
            // Si ya se está reproduciendo un sonido, crear un nuevo AudioSource
            AudioSource newSfxSource = CreateNewSfxSource();
            newSfxSource.PlayOneShot(sfxClips[index]);
        }
        else
        {
            // Si no, usar el principal
            sfxAudioSource.PlayOneShot(sfxClips[index]);
        }
    }

    private AudioSource CreateNewSfxSource()
    {
        AudioSource newSfxSource = new GameObject("SfxAudioSource").AddComponent<AudioSource>();
        newSfxSource.outputAudioMixerGroup = sfxAudioSource.outputAudioMixerGroup;
        newSfxSource.volume = sfxAudioSource.volume;
        newSfxSource.playOnAwake = false;
        sfxSourceStack.Push(newSfxSource);
        return newSfxSource;
    }

    // Limpiar fuentes de audio inactivas
    private void Update()
    {
        if (sfxSourceStack.Count > 0)
        {
            AudioSource topSource = sfxSourceStack.Peek();
            if (topSource.isPlaying == false)
            {
                Destroy(topSource.gameObject);
                sfxSourceStack.Pop();
            }
        }
    }
}