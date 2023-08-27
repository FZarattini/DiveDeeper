using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CaveScript : MonoBehaviour
{

    [SerializeField, ReadOnly] AudioSource _audioSource;
    [SerializeField] AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.ChangeClip(_clip);
    }
}
