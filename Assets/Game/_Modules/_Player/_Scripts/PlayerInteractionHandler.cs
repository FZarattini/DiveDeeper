using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField] IInteractables currentInteractable = null;


    // Saves the collided interactable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractables interactable = collision.GetComponent<IInteractables>();

        if(interactable != null)
            currentInteractable = interactable;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentInteractable = null;
    }

    // Executes interaction behaviour
    public void Interact()
    {
        if (currentInteractable == null) return;

        currentInteractable.Interact();
    }

}
