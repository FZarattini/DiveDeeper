using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWeapon : MonoBehaviour
{

    [SerializeField] GameObject _weaponObject;
    

    public void DisableWeaponObj()
    {
        _weaponObject.SetActive(false);
    }
}
