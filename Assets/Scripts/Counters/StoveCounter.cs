using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    
    public override void Interact (Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                //player is carrying something that can be fried
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this); //if player is carrying something, then put it on the counter and set parent to counter

                }
            }
            else
            {
                //player is not carrying anything
            }
        }
        else
        {
            //some KitchenObject here
            if (player.HasKitchenObject())
            {
                //player is carrying sometthing
            }
            else
            {
                //player is not carrying anything, pick up the KitchenObject on the counter
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO); //if there is a recipe for the input, return true
        return fryingRecipeSO != null; //if there is a recipe for the input, return true, if not, return false

    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null) //if there is a recipe for the input, return the output
        {
            return fryingRecipeSO.output; //return the output of the recipe
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray) //scrolls through list to find the correct output for the input
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO) //if array input matches the object we have, give the output
            {
                return fryingRecipeSO; //return the recipe that matches the input
            }
        }
        return null;


    }

}
