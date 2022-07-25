using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button hireMinersButton;

    // [SerializeField] private CinemachineVirtualCamera cam1;
    // [SerializeField] private CinemachineVirtualCamera cam3;

    public static GameManager instance;

    public GlowBlinker glow;

    public List<CameraZoomAdapter> cam = new List<CameraZoomAdapter>();
    public int ActiveCameraIndex { get; set; } = 0;

    private void Awake()
    {
        instance = this;
    }

    public void HireMoreMiners() // called through timeline
    {
        hireMinersButton.gameObject.SetActive(true);
        // hireMinersButton.GetComponentInChildren<TMP_Text>().text = $"Hire more miners";

        // cam1.gameObject.SetActive(false);
    }

    public void LoadNextCamera()
    {
        var index = instance.ActiveCameraIndex;
        instance.cam[index].gameObject.SetActive(false);
        index++;
        instance.cam[index].gameObject.SetActive(true);
        instance.ActiveCameraIndex = index;
    }
    
    public void StartPhase4()
    {
        // cam3.gameObject.SetActive(true);
    }
}
