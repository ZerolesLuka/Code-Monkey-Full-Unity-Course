using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage;

    private void Update()
    {
        timerImage.fillAmount = GameHandler.Instance.GetGamePlayingTimerNormalized(); //sets the fill amount of the timer image to the normalized playing timer, which is a value between 0 and 1 that represents how much time is left in the game
    }
}
