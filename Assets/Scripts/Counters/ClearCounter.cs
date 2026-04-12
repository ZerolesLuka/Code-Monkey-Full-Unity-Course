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

}
