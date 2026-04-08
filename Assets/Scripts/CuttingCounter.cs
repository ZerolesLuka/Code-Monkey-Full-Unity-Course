using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray; //array of all the possible cutting recipes

    private int cuttingProgress;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //no KitchenObject here
            if (player.HasKitchenObject())
            {
                //player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))//if the object the player is carrying can be cut, then put it on the counter 
                {
                    //Player carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this); //if player is carrying something, then put it on the counter and set parent to player
                    cuttingProgress = 0;
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

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            
            //There is a KitchenObject here AND it can be cut
            cuttingProgress++;

            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            
            GetKitchenObject().DestroySelf(); //gets rid of the current object on the counter

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this); //spawns in a prefab of object on interact
            


        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO); //if there is a recipe for the input, return true
        return cuttingRecipeSO != null; //if there is a recipe for the input, return true, if not, return false
        
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (cuttingRecipeSO != null) //if there is a recipe for the input, return the output
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null; 
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) //scrolls through list to find the correct output for the input
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) //if array input matches the object we have, give the output
            {
                return cuttingRecipeSO;
            }
        }
        return null;
        Debug.LogError("RecipeSO for " + inputKitchenObjectSO.name + " not found!"); //if there is no recipe for the input, log an error

    }
}
