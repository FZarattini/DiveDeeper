using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue/New Dialogue", order = 1)]
public class DialogueSO : ScriptableObject
{
    public Characters character;
    public List<string> dialogueText;
    public float writeSpeed;
    [ReadOnly] public bool completed = false;
}

public enum Characters
{
    None,
    Jimmy,
    Tony,
    Cindy,
    Mary,
    Luke,
    FatherTravis,
    Hugh,
    Marlowe,
    Maxwell,
    Squeaker,
    Rat,
    Diary,
    Gizmo,
}
