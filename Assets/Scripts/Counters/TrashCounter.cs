using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()) //if player has object, destroy it
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
