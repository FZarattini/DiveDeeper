using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseScript : MonoBehaviour, IInteractables
{
    [SerializeField] UIContainer _fadeContainer;
    [SerializeField] float timeToWait;
    [SerializeField] GameObject playerNormal;
    [SerializeField] GameObject playerLyingDown;
    [SerializeField] DialogueTrigger _dialogueTrigger;
    [SerializeField] AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.ChangeClip(_clip);
        StartCoroutine("HideFade");
    }

    IEnumerator HideFade()
    {
        _fadeContainer.Hide();

        yield return new WaitForSeconds(timeToWait);

        _fadeContainer.Show();

        yield return new WaitForSeconds(timeToWait);

        _fadeContainer.Hide();
    }

    public void SwitchCharacters()
    {
        playerLyingDown.SetActive(false);
        playerNormal.SetActive(true);
    }

    void DialogueCallback()
    {
        StartCoroutine("ShowFadeAndLoadGraveyard");
    }

    IEnumerator ShowFadeAndLoadGraveyard()
    {
        _fadeContainer.Show();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Graveyard");
    }

    public void PlayDiaryDialogue()
    {
        _dialogueTrigger.PlayDialogue(DialogueCallback);
    }

    public void Interact()
    {
        PlayDiaryDialogue();
    }
}
