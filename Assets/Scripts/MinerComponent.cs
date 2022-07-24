using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class MinerComponent : MonoBehaviour
{
    [SerializeField] private GameObject prefabText;
    [SerializeField] private float offset;
    [SerializeField] private Transform target;

    [SerializeField] private AudioClip spawnClip;
    [SerializeField] private AudioClip mineClip;
    
    [SerializeField] private float miningValue;
    private void OnEnable()
    {
        PlaySound(spawnClip);

        prefabText.GetComponent<TMP_Text>().text = $"+{miningValue}";

        StartCoroutine(FallDownSpawnEffect());
    }

    private IEnumerator FallDownSpawnEffect()
    {
        float counter = 0;
        while (counter <= 0.3f)
        {
            counter += Time.deltaTime;
            
            Vector3 transformPosition = transform.position;
            transformPosition.y -= Time.deltaTime;
            transform.position = transformPosition;
            
            yield return null;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    
    public void GatherGold()
    {
        // text.gameObject.SetActive(true);
        // text.text = "+10";

        var popUpText = Instantiate(prefabText, target.position, Quaternion.identity);
        
        popUpText.transform.position +=
            new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), Random.Range(-offset, offset));
        popUpText.GetComponent<AlphaFader>().FadeText();
        popUpText.GetComponent<AlphaFader>().destroyOnFinish = true;

        PlaySound(mineClip);
    }
}
