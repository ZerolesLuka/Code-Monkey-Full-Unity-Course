using System.Runtime.CompilerServices;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged; //gets the instance of the player 
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == baseCounter) //if the selected counter is the same as the clear counter, then show the visual select
        {
            Show(); //show visual
        }
        else
        {
            Hide(); //hide visual
        }
    }


    private void Show()
    {
        foreach(GameObject visualGameObject in visualGameObjectArray) //goes through each game object in the array and sets it to active
            visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray) //goes through each game object in the array and sets it to active
        visualGameObject.SetActive(false);
    }
}
