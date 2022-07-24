using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraZoomAdapter : MonoBehaviour
{
    [SerializeField] private float portraitSize;
    [SerializeField] private float landscapeSize;

    private CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation is ScreenOrientation.Portrait or ScreenOrientation.PortraitUpsideDown)
        {
            cam.m_Lens.OrthographicSize = portraitSize;
        }
        else
        {
            cam.m_Lens.OrthographicSize = landscapeSize;
        }
    }
}
