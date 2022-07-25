using System.Collections;
using UnityEngine;

public class AlphaFader : MonoBehaviour
{
	[SerializeField] private float speed = 1;
 	// [SerializeField] private TMP_Text text;
    public bool destroyOnFinish = false;
    
    public void FadeText()
    {
	    StartCoroutine(Fade());
    }
    
    public void UnfadeText()
    {
	    // var textColor = text.color;
		// textColor.a = 1;
		// text.color = textColor;
    }

    private IEnumerator Fade()
	{
		// var textColor = text.color;
		// while (textColor.a > 0)
		{
			// textColor.a -= speed * Time.deltaTime;
			// text.color = textColor;
			yield return null;
		}

		if (destroyOnFinish)
		{
			Destroy(gameObject);
		}
	}
	
	
}
