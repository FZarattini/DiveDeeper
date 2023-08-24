using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SortingGroup))]
public class DynamicSortingOrder : MonoBehaviour
{
    private SortingGroup sortingGroup;

    private void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();

        SetSortingLayer();
    }

    private void SetSortingLayer()
    {
        sortingGroup.sortingLayerName = "Dynamic";
    }

    private void Update()
    {
        sortingGroup.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}
