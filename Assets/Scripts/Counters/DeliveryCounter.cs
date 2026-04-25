using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()){ //if something
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))//if it's a plate
            { 
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

                player.GetKitchenObject().DestroySelf(); //destroy the plate on player
            }
            
        }
    }
}
