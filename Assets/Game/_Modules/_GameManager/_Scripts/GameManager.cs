using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Title("References")]
    [SerializeField] PlayerData _playerData = null;

    [Title("GameStates")]
    [SerializeField, ReadOnly] bool onDialogue = false;
    [SerializeField, ReadOnly] bool isAttacking = false;
    [SerializeField, ReadOnly] bool isGettingKnockback = false;
    [SerializeField, ReadOnly] bool onPlayerChoice = false;
    [SerializeField, ReadOnly] bool foundRat = false;

    [Title("Global Values")]

    [SerializeField] int playerCurrency;

    public bool OnDialogue
    {
        get => onDialogue;
        set => onDialogue = value;
    }

    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }

    public bool IsGettingKnockback
    {
        get => isGettingKnockback;
        set => isGettingKnockback = value;
    }

    public bool FoundRat
    {
        get => foundRat;
        set => foundRat = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        DialogueManager.OnDialogueStart += delegate { onDialogue = true; };
        DialogueManager.OnDialogueFinish += delegate { onDialogue = false; };
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueStart -= delegate { onDialogue = true; };
        DialogueManager.OnDialogueFinish -= delegate { onDialogue = false; };
    }

    public bool CanMoveOrInteract()
    {
        return !onDialogue && !onPlayerChoice;
    }

}
