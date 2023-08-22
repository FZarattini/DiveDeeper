using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class PlayerEquipmentController : MonoBehaviour
{
    [Title("References")]
    [SerializeField, ReadOnly] GameObject _hatObj;
    [SerializeField, ReadOnly] GameObject _bodyObj;
    [SerializeField] Animator _hatAnimator = null;
    [SerializeField] Animator _bodyAnimator = null;


    // Changes clothes animator state based on the player state
    public void ChangeClothesAnimatorState(PlayerAnimationStates animationState)
    {
        if(_hatAnimator != null)
            _hatAnimator.Play(animationState.ToString());
        if(_bodyAnimator != null)
            _bodyAnimator.Play(animationState.ToString());
    }
}
