using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderComponent : MonoBehaviour
{
    private int upgradeLevel = 0;

    [SerializeField] private SpriteRenderer[] corridorRenderer;
    [SerializeField] private GameObject[] newMiners;
    [SerializeField] private GameObject[] oldMiners;
    
    [SerializeField] private Sprite[] corridorSpriteVersion;
    [SerializeField] private string[] buttonTextList;

    [SerializeField] private CameraZoomAdapter cam;
    private Button button;

    public event Action OnLastUpgradeEnd;
    
    private bool canBeClickedAgain = true;
    void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(Upgrade);
        
        OnLastUpgradeEnd += GameManager.instance.StartPhase4;
        OnLastUpgradeEnd += DeactivateObject;

    }

    public void Upgrade()
    {
        if (canBeClickedAgain == false) return;
        
        ++upgradeLevel;

        StartCoroutine(Shake());
        StartCoroutine(ManipulateButtonActivation());
        
        // PlaySound();

        SwapSprites();
        SwapText();
    }

    private IEnumerator Shake()
    {
        ShakeScreen(upgradeLevel);

        yield return new WaitForSeconds(0.1f * upgradeLevel);
        
        ShakeScreen(0);
    }

    private IEnumerator ManipulateButtonActivation()
    {
        canBeClickedAgain = false;

        yield return new WaitForSeconds(0.1f * upgradeLevel);

        canBeClickedAgain = true;
        
        if (upgradeLevel == corridorSpriteVersion.Length - 1)
        {
            OnLastUpgradeEnd?.Invoke();
        }
    }
    
    private void ShakeScreen(float value)
    {
        // cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = value;
        // cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = value;
    }

    private void DeactivateObject()
    {
        button.onClick.RemoveListener(Upgrade);
        gameObject.SetActive(false);
    }

    private void SwapSprites()
    {
        foreach (var renderer in corridorRenderer)
        {
            renderer.sprite = corridorSpriteVersion[upgradeLevel];
        }
        
        if (upgradeLevel == corridorSpriteVersion.Length - 1)
        {
            SwapMinersSprites();
        }
    }

    private void SwapMinersSprites()
    {
        if (newMiners.Length != oldMiners.Length)
        {
            Debug.LogError($"oldMiners and newMiners dont have the same numbers", this);
            return;
        }

        for (int i = 0; i < newMiners.Length; i++)
        {
            newMiners[i].SetActive(true);
            oldMiners[i].SetActive(false);
        }
    }
    
    private void SwapText()
    {
        // button.GetComponentInChildren<TMP_Text>().text = buttonTextList[upgradeLevel];
    }
}
