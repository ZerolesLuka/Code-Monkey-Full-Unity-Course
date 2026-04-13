using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject 
{
    public KitchenObjectSO input; //the kitchen object that is the input of the cutting recipe
    public KitchenObjectSO output; //the kitchen object that is the output of the cutting recipe
    public float fryingTimerMax; //the time it takes to fry the input into the output


}
