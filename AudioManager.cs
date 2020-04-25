using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        _instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayAudioByName(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/CanonTowerShoot" + name);
    }
}
