using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatDialogueTrigger : DialogueTrigger
{
    [SerializeField] private string loadSceneName;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
