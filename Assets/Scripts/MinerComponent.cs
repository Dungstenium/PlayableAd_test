// using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MinerComponent : BaseCharacter
{
    [SerializeField] private GameObject prefabText;
    [SerializeField] private float offset;
    [SerializeField] private Transform target;

    [SerializeField] private AudioClip mineClip;
    
    [SerializeField] private float miningValue;
    private void OnEnable()
    {
        prefabText.GetComponent<Text>().text = $"+{miningValue}";

        base.OnEnable();
    }
    
    public void GatherGold()
    {
        var popUpText = Instantiate(prefabText, target.position, Quaternion.identity);
        
        popUpText.transform.position +=
            new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), Random.Range(-offset, offset));
        popUpText.GetComponent<AlphaFader>().FadeText();
        popUpText.GetComponent<AlphaFader>().destroyOnFinish = true;

        PlaySound(mineClip);
    }
}
