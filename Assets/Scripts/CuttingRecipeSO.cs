using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject 
{
    public KitchenObjectSO input; //the kitchen object that is the input of the cutting recipe
    public KitchenObjectSO output; //the kitchen object that is the output of the cutting recipe
    public int cuttingProgressMax; //the amount of cuts needed to cut the input into the output 


}
