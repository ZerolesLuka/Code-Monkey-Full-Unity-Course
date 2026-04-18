using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //no KitchenObject here
            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this); //if player is carrying something, then put it on the counter and set parent to player
            }
            else
            {
                //player is not carrying anything

            }

        }
        else
        {
            //some KitchenObject here
            if (player.HasKitchenObject()) //if player has
            {
                //player is carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) //has a plate...
                {
                    //Player holding plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) //has ingredient that can be added to plate...
                    {
                        GetKitchenObject().DestroySelf();
                    }

                }
                else
                {
                    //Player not holding plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject)) //try if counter has plate
                    {
                        //Counter has plate 
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) //try to add ingredient to plate
                        {
                            player.GetKitchenObject().DestroySelf(); //get rid of ingredient on player
                        }

                    }

                }

            }
            else
            {
                //Player not holding plate
                GetKitchenObject().SetKitchenObjectParent(player);
            }


        }

    }  

}
