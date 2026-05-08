using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            //click code...
            SceneManager.LoadScene(1);
        });
        quitButton.onClick.AddListener(() =>
        {
            //click code...
            Application.Quit();
        });

    }

    /*private void PlayClick()
    {
        //could've been placed inside the listener, keep in mind...
    }*/
}
