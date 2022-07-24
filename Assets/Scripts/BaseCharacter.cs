using System.Collections;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private AudioClip spawnClip;

    public virtual void OnEnable()
    {
        StartCoroutine(FallDownSpawnEffect());

        PlaySound(spawnClip);
    }

    protected virtual IEnumerator FallDownSpawnEffect()
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

    protected void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
