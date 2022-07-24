using UnityEngine;

public class CameraZoomAdapter : MonoBehaviour
{
    [SerializeField] private float portraitSize;
    [SerializeField] private float landscapeSize;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
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
