using UnityEngine;
using UnityEngine.Rendering;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator animator;

    private const string CUT = "Cut"; //name of the trigger in the animator

    [SerializeField] private CuttingCounter cuttingCounter;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }  
    
    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }


}
