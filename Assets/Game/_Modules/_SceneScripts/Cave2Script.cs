using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Cave2Script : MonoBehaviour
{
    [SerializeField, ReadOnly] AudioSource _audioSource;
    [SerializeField] AudioClip _sadSong;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();

        _audioSource.clip = _sadSong;
    }
}
