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
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            //click code...
            Application.Quit();
        });
        Time.timeScale = 1f;
    }

    /*private void PlayClick()
    {
        //could've been placed inside the listener, keep in mind...
    }*/
}
