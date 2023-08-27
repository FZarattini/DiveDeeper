using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChaseCutscene : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private CharacterController characterFleeing;

    [SerializeField, Range(0, 5)] private float distanceToFlee;

    [SerializeField] private FollowTarget rat;
    [SerializeField] private GameObject caveEntranceMask;
    [SerializeField] private GameObject caveEntranceTrigger;

    [SerializeField] private Transform initialPoint;
    [SerializeField] private List<Transform> fleePoints;
    [SerializeField] private Transform throwRatPoint;
    private int fleePointIndex;

    private bool isFleeing;
    private float distanceToPlayer;

    [Header("DIALOGUE TRIGGERS")]
    [SerializeField] private Tony_DialogueTrigger tony_DialogueTrigger;
    [SerializeField] private Tony_DialogueTrigger tony_End_DialogueTrigger;
    [SerializeField] private DialogueTrigger endChaseDialogue;

    [ContextMenu("START")]
    public void StartChase()
    {
        MoveToInitialPosition();
    }

    private void MoveToInitialPosition()
    {
        MoveToPosition(initialPoint.position).OnComplete(() => tony_DialogueTrigger.Interact());
    }

    public void StealRat()
    {
        rat.enabled = false;

        MoveToPosition(rat.transform.position).OnComplete(() =>
        {
            rat.gameObject.SetActive(false);

            GoToNextFleePoint().OnComplete(ArrivedAtPosition);
        });
    }

    private void ThrowRat()
    {
        rat.transform.position = new Vector2(characterFleeing.transform.position.x, characterFleeing.transform.position.y + 1);
        rat.GetComponent<SpriteRenderer>().sortingLayerName = "Above Player";

        rat.gameObject.SetActive(true);
        caveEntranceMask.SetActive(true);

        rat.transform.DOMoveY(throwRatPoint.position.y, 1f).SetEase(Ease.InBack).OnComplete(() =>
        {
            rat.gameObject.SetActive(false);

            tony_End_DialogueTrigger.Interact();
        });
    }


    public void EndChaseDialogue()
    {
        endChaseDialogue.Interact();

        caveEntranceTrigger.SetActive(true);
    }

    private Tween GoToNextFleePoint()
    {
        if (fleePointIndex == fleePoints.Count)
        {
            ThrowRat();
            return null;
        }

        Transform point = fleePoints[fleePointIndex];
        fleePointIndex++;

        return MoveToPosition(point.position);
    }

    private void ArrivedAtPosition()
    {
        characterFleeing.MoveCharacter(Vector2.down, 0);

        isFleeing = true;
    }

    private Tween MoveToPosition(Vector3 position)
    {
        Vector2 direction = (position - characterFleeing.transform.position).normalized;
        characterFleeing.MoveCharacter(direction, 1);

        return characterFleeing.transform.DOMove(position, Vector2.Distance(position, characterFleeing.transform.position) * 0.2f);
    }

    private void Update()
    {
        if (!isFleeing)
            return;

        distanceToPlayer = Vector2.Distance(characterFleeing.transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFlee)
        {
            isFleeing = false;

            GoToNextFleePoint().OnComplete(ArrivedAtPosition);
        }
    }
}
