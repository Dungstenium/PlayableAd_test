using System;
using UnityEngine;

public class CameraZoomAdapter : MonoBehaviour
{
    [SerializeField] private float portraitSize;
    [SerializeField] private float landscapeSize;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        cam.transform.position = transform.position;
    }

    private void Update()
    {
        if (Screen.orientation is ScreenOrientation.Portrait or ScreenOrientation.PortraitUpsideDown)
        {
            cam.orthographicSize = portraitSize;
        }
        else
        {
            cam.orthographicSize = landscapeSize;
        }
    }
}
