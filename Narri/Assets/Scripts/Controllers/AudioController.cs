using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Utility;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioController instance;

    private void Start()
    {

       
       
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            InitializeSound(sound);
        }
    }

    public void InitializeSound(Sound sound)
    {
        //add component
        sound.source = gameObject.AddComponent<AudioSource>();
        //add values to component
        sound.source.clip = sound.clip;
        sound.source.pitch = sound.pitch;
        sound.source.volume = sound.volume;
        sound.source.loop = sound.loop;
    }

    public bool IsPlaying(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            return false;
        }
        return sound.source.isPlaying;
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            return;
        }
        sound.source.Play();
    }

    public void PlayRandomWithPrefix(string prefix)
    {
        Sound sound = sounds.Where(sound => sound.name.StartsWith(prefix)).ToList().GetRandomFromList();
        if (sound == null)
        {
            return;
        }
        sound.source.Play();
    }
}