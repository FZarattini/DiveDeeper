using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatDialogueTrigger : DialogueTrigger
{
    [SerializeField] private string loadSceneName;

    [SerializeField] private UIContainer container;

    public override void Interact()
    {
        OnDialogueInteracted?.Invoke(_dialogue, Fade);
    }

    private void Fade()
    {
        container.Show();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
