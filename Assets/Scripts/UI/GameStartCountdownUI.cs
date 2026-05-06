using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    private void Start()
    {
        GameHandler.Instance.OnStateChanged += GameHandler_OnStateChanged;
        Hide();
    }

    private void GameHandler_OnStateChanged(object sender, System.EventArgs e)
    {
        if(GameHandler.Instance.IsCountingDownToStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Update()
    {
        if (GameHandler.Instance.IsCountingDownToStart())
        {
            countdownText.text = GameHandler.Instance.GetCountdownToStartTimer().ToString();
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
