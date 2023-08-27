using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScreenshotManager : MonoBehaviour
{
    [SerializeField, HideInInspector] int quantity = 1;

    [Button]
    public void TakeScreenShot()
    {
        ScreenCapture.CaptureScreenshot($"{quantity.ToString()}.png");
        quantity++;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
