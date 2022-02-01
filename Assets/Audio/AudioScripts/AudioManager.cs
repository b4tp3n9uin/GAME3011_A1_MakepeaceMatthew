using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;

    void Awake()
    {
        foreach (Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.name = s.name;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sound, _sound => _sound.name == name);
        s.source.Play();
    }
}
