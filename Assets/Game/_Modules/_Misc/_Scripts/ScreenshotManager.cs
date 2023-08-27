using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScreenshotManager : MonoBehaviour
{
    [SerializeField, HideInInspector] int quantity = 0;

    [Button]
    public void TakeScreenShot()
    {
        ScreenCapture.CaptureScreenshot(quantity.ToString());
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
