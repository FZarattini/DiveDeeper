using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using Doozy.Runtime.Colors.Models;

public class CharacterController : MonoBehaviour
{
    [Title("References")]
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Rigidbody2D _rigidBody;


    [SerializeField] CharacterAnimationStates defaultState;
    [SerializeField, ReadOnly] CharacterAnimationStates currentState;
    [SerializeField] CharacterEquipmentController _CharacterEquipmentController;


    public Vector2 PushDirection;

    private void Start()
    {
        ChangeAnimatorState(defaultState);
    }

    // Moves the character based on the movement vector and speed
    public void MoveCharacter(Vector2 moveVector, float speed)
    {
        _rigidBody.velocity = moveVector * speed;

        if (_rigidBody.velocity == Vector2.zero || GameManager.Instance.OnDialogue)
        {
            if (!IsIdleState())
                SetIdle();
        }
        else
        {
            if (PushDirection != Vector2.zero)
            {
                HandlePushingAnimation();
            }
            else
            {
                HandleNewMovement();
            }

            SetDirection();
        }

    }

    // Chooses which Idle animation should be played based on the players last movement
    void SetIdle()
    {
        switch (currentState)
        {
            case CharacterAnimationStates.IDLE_HORIZONTAL:
            case CharacterAnimationStates.IDLE_DOWN:
            case CharacterAnimationStates.IDLE_UP:
                return;

            case CharacterAnimationStates.WALK_HORIZONTAL:
            case CharacterAnimationStates.PUSH_HORIZONTAL:
                ChangeAnimatorState(CharacterAnimationStates.IDLE_HORIZONTAL);
                break;

            case CharacterAnimationStates.WALK_UP:
            case CharacterAnimationStates.PUSH_UP:
                ChangeAnimatorState(CharacterAnimationStates.IDLE_UP);
                break;

            case CharacterAnimationStates.WALK_DOWN:
            case CharacterAnimationStates.PUSH_DOWN:
                ChangeAnimatorState(CharacterAnimationStates.IDLE_DOWN);
                break;

            default:
                break;

        }
    }


    // Handles the change in movement deciding which animation should be called, prioritizing last movement animation over new movement
    void HandleNewMovement()
    {
        switch (currentState)
        {
            case CharacterAnimationStates.WALK_HORIZONTAL:
            case CharacterAnimationStates.PUSH_HORIZONTAL:

                if (_rigidBody.velocity.x == 0 && _rigidBody.velocity.y != 0)
                {
                    if (_rigidBody.velocity.y > 0)
                    {
                        ChangeAnimatorState(CharacterAnimationStates.WALK_UP);
                    }
                    else
                    {
                        ChangeAnimatorState(CharacterAnimationStates.WALK_DOWN);
                    }
                }
                else
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_HORIZONTAL);
                }

                break;

            case CharacterAnimationStates.WALK_UP:
            case CharacterAnimationStates.PUSH_UP:

                if (_rigidBody.velocity.y == 0 && _rigidBody.velocity.x != 0)
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_HORIZONTAL);
                }
                else if (_rigidBody.velocity.y < 0)
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_DOWN);
                }
                else
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_UP);
                }

                break;

            case CharacterAnimationStates.WALK_DOWN:
            case CharacterAnimationStates.PUSH_DOWN:

                if (_rigidBody.velocity.y == 0 && _rigidBody.velocity.x != 0)
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_HORIZONTAL);
                }
                else if (_rigidBody.velocity.y > 0)
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_UP);
                }
                else
                {
                    ChangeAnimatorState(CharacterAnimationStates.WALK_DOWN);
                }

                break;

            case CharacterAnimationStates.IDLE_HORIZONTAL:
            case CharacterAnimationStates.IDLE_DOWN:
            case CharacterAnimationStates.IDLE_UP:

                ChangeAnimatorState(CharacterAnimationStates.WALK_HORIZONTAL);

                break;

            default:
                break;
        }
    }

    private void HandlePushingAnimation()
    {
        if (Mathf.Abs(PushDirection.x) > Mathf.Abs(PushDirection.y))
        {
            if (PushDirection.x >= 0)
            {
                ChangeAnimatorState(CharacterAnimationStates.PUSH_HORIZONTAL);
            }
            else if (PushDirection.x < 0)
            {
                ChangeAnimatorState(CharacterAnimationStates.PUSH_HORIZONTAL);
            }
        }
        else
        {
            if (PushDirection.y >= 0)
            {
                ChangeAnimatorState(CharacterAnimationStates.PUSH_DOWN);
            }
            else
            {
                ChangeAnimatorState(CharacterAnimationStates.PUSH_UP);
            }
        }
    }

    // Changes the character animation based on the new state
    void ChangeAnimatorState(CharacterAnimationStates newState)
    {
        if (currentState == newState) return;

        _animator.Play(newState.ToString());
        _CharacterEquipmentController.ChangeClothesAnimatorState(newState);

        currentState = newState;
    }

    // Flips the sprite of the Character using the absolute values of the scale instead of 1f in case scale values need to be changed in the future
    void SetDirection()
    {
        if (_rigidBody.velocity.x < 0)
            _spriteRenderer.transform.localScale = new Vector3(-Mathf.Abs(_spriteRenderer.transform.localScale.x), _spriteRenderer.transform.localScale.y, _spriteRenderer.transform.localScale.z);
        else
            _spriteRenderer.transform.localScale = new Vector3(Mathf.Abs(_spriteRenderer.transform.localScale.x), _spriteRenderer.transform.localScale.y, _spriteRenderer.transform.localScale.z);
    }

    // Checks is player is in any of the Idle States
    bool IsIdleState()
    {
        return currentState == CharacterAnimationStates.IDLE_HORIZONTAL || currentState == CharacterAnimationStates.IDLE_UP || currentState == CharacterAnimationStates.IDLE_DOWN;
    }

    // Forces player to look down to the camera
    void ForceIdleDownState()
    {
        _rigidBody.velocity = Vector2.zero;
        ChangeAnimatorState(CharacterAnimationStates.IDLE_DOWN);
    }

    // Forces player to look up with the back to the camera
    void ForceIdleUpState()
    {
        _rigidBody.velocity = Vector2.zero;
        ChangeAnimatorState(CharacterAnimationStates.IDLE_UP);
    }
}

public enum CharacterAnimationStates
{
    IDLE_UP,
    IDLE_HORIZONTAL,
    IDLE_DOWN,
    WALK_UP,
    WALK_HORIZONTAL,
    WALK_DOWN,
    PUSH_UP,
    PUSH_HORIZONTAL,
    PUSH_DOWN,
}
