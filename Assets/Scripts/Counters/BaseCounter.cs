using System;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public static event EventHandler OnAnyObjectPlacedHere; 
    [SerializeField] private Transform counterTopPoint;
    
    
    private KitchenObject kitchenObject;


    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact()");
    }

    public virtual void InteractAlternate(Player player)
    {
        //Debug.LogError("BaseCounter.InteractAlternate()");
    }



    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;//sets the kitchen object on the counter to the kitchen object passed in

        if (kitchenObject != null)
            {
                OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty); //invokes the event when a kitchen object is placed on the counter
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject; //returns the kitchen object on the counter
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null; //clears the kitchen object on the counter
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null; //returns true if there is a kitchen object on the counter and false if there is not
    }

}
