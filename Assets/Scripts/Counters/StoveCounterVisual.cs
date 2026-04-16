using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter; //stove
    [SerializeField] private GameObject stoveOnGameObject; //stove on
    [SerializeField] private GameObject particlesGameObject; //stove particles

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;


    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried; //sets bool active if these states are active
        stoveOnGameObject.SetActive(showVisual); //bool is used as parameter to set active or inactive
        particlesGameObject.SetActive(showVisual); //bool is used as parameter to set active or inactive
    }
}
