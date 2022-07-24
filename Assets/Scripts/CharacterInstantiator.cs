using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    public void InstatiateCharacter(Transform spawnPoint, float delay)
    {
        StartCoroutine(InstatiateAfterSeconds(spawnPoint));
    }

    private IEnumerator InstatiateAfterSeconds(Transform spawnPoint)
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
