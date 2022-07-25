using UnityEngine;
using UnityEngine.UI;

public class MinerComponent : BaseCharacter
{
    [SerializeField] private GameObject prefabText;

    [SerializeField] private AudioClip mineClip;
    
    [SerializeField] private float miningValue;
    
    private new void OnEnable()
    {
        prefabText.GetComponent<Text>().text = $"+{miningValue}";

        base.OnEnable();
    }
    
    public void GatherGold()
    {
        PlaySound(mineClip);
    }
}
