using System;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyObjectTrashed; //static event that can be listened to by any script, invoked when any object is trashed   

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject()) //if player has object, destroy it
        {
            player.GetKitchenObject().DestroySelf();
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty); //invoke the event to notify listeners that an object has been trashed
        }
    }
}
