using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class TapButtonHandler : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Button nextButton;
    private AlphaFader fader;

    [SerializeField] private List<GameObject> minersList = new List<GameObject>();
    [SerializeField] private Animator minerAnim;

    private void Start()
    {
        fader = button.GetComponentInChildren<AlphaFader>();

        AssignPhaseOneEvents();
    }

    private void AssignPhaseOneEvents()
    {
        button.onClick.AddListener(() => GameManager.instance.glow.gameObject.SetActive(false));
        button.onClick.AddListener(() => StartCoroutine(AnimateFirstMiner()));
        button.onClick.AddListener(() => button.gameObject.SetActive(false));
    }

    private IEnumerator AnimateFirstMiner()
    {
        minerAnim.SetBool("ShouldMine", true);

        yield return new WaitForSeconds(minerAnim.GetCurrentAnimatorClipInfo(0).Length * 3);
        
        minerAnim.SetBool("ShouldMine", false);
        
        UnassignPhaseOneEvents();
        button.gameObject.SetActive(true);
    }

    private void UnassignPhaseOneEvents()
    {
        button.onClick.RemoveAllListeners();

        AssignPhaseTwoEvents();
    }

    private void AssignPhaseTwoEvents()
    {
        for (int i = 0; i < minersList.Count; i++)
        {
            var delay = (i + 1) * 0.5f;
            var miner = minersList[i];
            
            button.onClick.AddListener(() => StartCoroutine(ObjectActivation(miner, delay)));
        }

        button.onClick.AddListener(() => GameManager.instance.glow.gameObject.SetActive(false));
            
        button.onClick.AddListener(() => StartCoroutine(ObjectActivation(nextButton.gameObject, 3.0f)));
        
        button.onClick.AddListener(() => button.gameObject.SetActive(false));

        GameManager.instance.LoadNextCamera();
        
        button.onClick.AddListener(() => StartCoroutine(UnassignAfterTime(3.0f)));
    }

    private IEnumerator ObjectActivation(GameObject goToActivate,float delay)
    {
        yield return new WaitForSeconds(delay);
        
        goToActivate.SetActive(true);
    }

    private IEnumerator UnassignAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);

        UnassignPhaseTwoEvents();
    }
    
    private void UnassignPhaseTwoEvents()
    {
        button.onClick.RemoveAllListeners();
        
        GameManager.instance.LoadNextCamera();
    }
}
