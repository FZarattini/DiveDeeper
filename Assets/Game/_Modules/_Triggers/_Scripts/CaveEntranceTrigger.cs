using DG.Tweening;
using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveEntranceTrigger : MonoBehaviour, IInteractables
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform caveJumpEndPoint;
    [SerializeField] private GameObject caveEntranceMask;

    [SerializeField] private UIContainer container;

    private bool interacted;

    [ContextMenu("INTERACT")]
    public void Interact()
    {
        if (interacted)
            return;

        interacted = true;

        caveEntranceMask.SetActive(true);
        player.DOJump(caveJumpEndPoint.position, 2f, 1, 1.2f).SetEase(Ease.InQuad).OnComplete(() => container.Show());
    }

    public void LoadCaveScene()
    {
        SceneManager.LoadScene("Cave");
    }
}
