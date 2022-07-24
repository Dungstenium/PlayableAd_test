using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button hireMinersButton;
    [SerializeField] private Transform target;

    [SerializeField] private CinemachineVirtualCamera cam1;

    public static GameManager instance;

    public GlowBlinker glow;
    [HideInInspector] public Camera cam;
    
    private void Awake()
    {
        instance = this;
        cam = Camera.main;
    }

    public void HireMoreMiners()
    {
        hireMinersButton.gameObject.SetActive(true);
        hireMinersButton.GetComponentInChildren<TMP_Text>().text = $"Hire more miners";

        // hireMinersButton.GetComponent<WorldPositionFixerComponent>().target = target;

        // glow.transform.position = (Vector2)cam.ScreenToWorldPoint(hireMinersButton.transform.position);

        cam1.gameObject.SetActive(false);
    }
}
