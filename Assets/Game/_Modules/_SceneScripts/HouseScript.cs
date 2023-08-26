using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    [SerializeField] UIContainer _fadeContainer;
    [SerializeField] float timeToWait;

    private void Start()
    {
        StartCoroutine("HideFade");
    }

    IEnumerator HideFade()
    {
        _fadeContainer.Hide();

        yield return new WaitForSeconds(timeToWait);

        _fadeContainer.Show();
    }
}
