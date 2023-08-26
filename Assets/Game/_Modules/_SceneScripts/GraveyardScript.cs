using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class GraveyardScript : MonoBehaviour
{
    [SerializeField, ReadOnly] AudioSource _audioSource;
    [SerializeField] AudioClip _sadSong;
    [SerializeField] DialogueTrigger _dialogueTrigger;
    [SerializeField] UIContainer _fadeContainer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _sadSong;
    }

    public void PlayDialogue()
    {
        _dialogueTrigger.PlayDialogue(ShowFadeContainer);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }

    void ShowFadeContainer()
    {
        _fadeContainer.Show();
    }
}
