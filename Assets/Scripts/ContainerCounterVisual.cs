using UnityEngine;
using UnityEngine.Rendering;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;

    private const string OPEN_CLOSE = "OpenClose"; //name of the trigger in the animator

    [SerializeField] private ContainerCounter containerCounter;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }  
    
    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject; //subscribes to the event OnPlayerGrabbedObject
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
