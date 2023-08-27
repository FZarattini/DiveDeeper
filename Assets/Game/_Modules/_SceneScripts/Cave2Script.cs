using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Cave2Script : MonoBehaviour
{
    [SerializeField, ReadOnly] AudioSource _audioSource;
    [SerializeField] AudioClip _sadSong;

    private void Start()
    {
        SoundManager.Instance.ChangeClip(_sadSong);
    }
}
