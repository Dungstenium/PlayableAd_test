using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button hireMinersButton;

    [SerializeField] private CinemachineVirtualCamera cam1;
    [SerializeField] private CinemachineVirtualCamera cam3;

    [SerializeField] private PlayableDirector _director;

    public static GameManager instance;

    public GlowBlinker glow;
    
    private void Awake()
    {
        instance = this;
    }

    public void HireMoreMiners() // called through timeline
    {
        hireMinersButton.gameObject.SetActive(true);
        hireMinersButton.GetComponentInChildren<TMP_Text>().text = $"Hire more miners";

        cam1.gameObject.SetActive(false);
    }
    
    public void StartPhase4()
    {
        cam3.gameObject.SetActive(true);
        // _director.playableAsset = timelineAsset;
        // _director.time = 0;
        _director.Play();
    }
}
