using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject; //event that is called when the player grabs an object from the counter

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player) //override the interact func from BaseCounter and pass in the player as a parameter
    {
        if (!player.HasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player); //spawns in a prefab of object on interact and sets the parent to the player so it appears in their hand
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty); //calls the event OnPlayerGrabbedObject
        }
        else
        {

        }
    }

}


