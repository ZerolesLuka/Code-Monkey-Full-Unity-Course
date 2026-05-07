using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    private void Start()
    {
        GameHandler.Instance.OnStateChanged += GameHandler_OnStateChanged;
        Hide();
    }

    private void GameHandler_OnStateChanged(object sender, System.EventArgs e)
    {
        
        
        if (GameHandler.Instance.IsGameOver())
        {
           Show();
           scoreText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        
        else
        {
            Hide();
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
