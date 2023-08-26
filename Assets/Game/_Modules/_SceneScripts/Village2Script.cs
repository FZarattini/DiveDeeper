using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village2Script : MonoBehaviour
{
    [SerializeField] GameObject VillageExitCollider;
    [SerializeField] GameObject VillageExitTeleport;

    public void EnableTeleport()
    {
        VillageExitCollider.SetActive(false);
        VillageExitTeleport.SetActive(true);
    }
}
