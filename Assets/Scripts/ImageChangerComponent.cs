using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangerComponent : MonoBehaviour
{
    [SerializeField] private Sprite portraitImage;
    [SerializeField] private Sprite landscapeImage;

    private float counter = 0;
    
    private Image imageComponent;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        
        SwapOrientationImage();
        ExpandImage();
    }

    private void OnRectTransformDimensionsChange()
    {
        SwapOrientationImage();
    }

    private void SwapOrientationImage()
    {
        if (imageComponent == null) return;

        if (Screen.orientation is ScreenOrientation.Portrait or ScreenOrientation.PortraitUpsideDown)
        {
            imageComponent.sprite = portraitImage;
        }
        else
        {
            imageComponent.sprite = landscapeImage;
        }
    }

    public void ExpandImage()
    {
        StartCoroutine(Expand());
    }

    private IEnumerator Expand()
    {
        while (true)
        {
            var localScale = imageComponent.rectTransform.localScale;
            localScale += localScale * 0.05f * Time.deltaTime;
            imageComponent.rectTransform.localScale = localScale;

            counter += Time.deltaTime;
            if (counter >= 3)
            {
                gameObject.SetActive(false);
            }
            
            yield return null;
        }
    }
}
