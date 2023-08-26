using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraveyardScript : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialogueTrigger;
    [SerializeField] UIContainer _fadeContainer;
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
