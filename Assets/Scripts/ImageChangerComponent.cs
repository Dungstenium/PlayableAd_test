using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ImageChangerComponent : MonoBehaviour
{
    [SerializeField] private Sprite portraitImage;
    [SerializeField] private Sprite landscapeImage;

    private Image imageComponent;

    private float width;
    private float height;
    
    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        
        SwapOrientationImage();
    }

    private void OnRectTransformDimensionsChange()
    {
        SwapOrientationImage();
    }

    private void SwapOrientationImage()
    {
        if (Screen.orientation is ScreenOrientation.Portrait or ScreenOrientation.PortraitUpsideDown)
        {
            imageComponent.sprite = portraitImage;
        }
        else
        {
            imageComponent.sprite = landscapeImage;
        }
        
        width = imageComponent.rectTransform.rect.width;
        height = imageComponent.rectTransform.rect.height;
    }

    public void ExpandImage()
    {
        StartCoroutine(Expand());
    }

    private IEnumerator Expand()
    {
        while (true)
        {
            width += width * 0.05f * Time.deltaTime;
            height += height * 0.05f * Time.deltaTime;
            
            imageComponent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            imageComponent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            imageComponent.rectTransform.ForceUpdateRectTransforms();
            yield return null;
        }
    }
}
