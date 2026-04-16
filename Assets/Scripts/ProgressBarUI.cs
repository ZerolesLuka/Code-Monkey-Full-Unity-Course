using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>(); //get the IHasProgress component from the game object
        if(hasProgress == null)
        {
            Debug.LogError("GameObject" + hasProgressGameObject + " does not have a component that implements IHasProgress!"); //if there is no IHasProgress component, log an error
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged; //subscribe to the event

        barImage.fillAmount = 0f; //progress bar starts empty

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized; //bar amount equals amount cut / amount to cut

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();

        }
    }

    private void Show()
    {
       gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }   
}
