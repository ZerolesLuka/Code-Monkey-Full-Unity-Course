using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject 
{
    public KitchenObjectSO input; //the kitchen object that is the input of the cutting recipe
    public KitchenObjectSO output; //the kitchen object that is the output of the cutting recipe
    public float burningTimerMax; //the time it takes to fry the input into the output


}
