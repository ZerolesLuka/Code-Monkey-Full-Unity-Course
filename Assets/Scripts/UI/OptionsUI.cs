using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{

    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button intButton;
    [SerializeField] private Button altButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI upText;
    [SerializeField] private TextMeshProUGUI downText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI intText;
    [SerializeField] private TextMeshProUGUI altText;
    [SerializeField] private TextMeshProUGUI pauseText;

    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            //click code...
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();

        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
        moveUpButton.onClick.AddListener(() =>
        {

        });
    }

    private void Start()
    {
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnpaused;
        UpdateVisual();
        Hide();
    }

    private void GameHandler_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide(); 
    }

    private void UpdateVisual()
    { 
        soundEffectsText.text = "Sound Effects : " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f).ToString();
        musicText.text = "Music : " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f).ToString();

        upText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        downText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        leftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        rightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        intText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        altText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
     private void Hide()
    {
        gameObject.SetActive(false);
    }
}
