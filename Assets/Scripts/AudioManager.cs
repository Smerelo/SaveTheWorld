using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager AudioInstance;
    private AudioSource source;
    private void Awake()
    {
        if (AudioInstance != null && AudioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        AudioInstance = this;
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }
    }

    private void Start()
    {
        Play("Menu");
    }

    public void PlayRandomSigh(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        s.source.pitch = UnityEngine.Random.Range(0.90f, 1.25f);
        s.source.Play();
    }

    public void Play(string name)
    {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        s.source.Play();
    }


    public void FadePlay(string name, float duration, bool play)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (play)
        {
            s.source.volume = 0;
            StartCoroutine(FadeVolume(s.volume, duration, s));
            s.source.Play();
        }
        else
        {
            StartCoroutine(FadeVolume(0, duration, s));
        }
    }


    IEnumerator FadeVolume(float endValue, float duration, Sound sound)
    {
        float time = 0;
        float startValue = sound.source.volume;

        while (time < duration)
        {
            sound.source.volume = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sound.source.volume = endValue;
        if (endValue == 0)
        {
            sound.source.Stop();
        }
    }

    public void Stop(string name)
    {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        s.source.Stop();
    }
}
