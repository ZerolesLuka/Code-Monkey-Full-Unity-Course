using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{


    private AudioSource audioSource;
    [SerializeField]private StoveCounter stoveCounter;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        stoveCounter = GetComponentInParent<StoveCounter>();
    }

}
