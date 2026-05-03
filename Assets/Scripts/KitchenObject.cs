using UnityEngine;
//comment so I can log music on git bc it's in the ignore
public class KitchenObject : MonoBehaviour
{

    [SerializeField]private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO; // returns the scriptable object associated with this kitchen object, which contains data like the prefab, sprite, and name
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) // sets the parent for whos holding what, and updates the visual position of the kitchen object to be on the counter
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent; // update the reference to the new counter

        if (kitchenObjectParent.HasKitchenObject()) // if the new counter already has a kitchen object, log an error (this should not happen in normal gameplay)
        {
            Debug.LogError("Ikitchenobjectparent already has a kitchen object!");
        }
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform(); //updates visual position of the object to be on the counter
        transform.localPosition = Vector3.zero; // resets the position to be exactly on the counter, in case it was offset before
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent; 
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject(); //clears the reference to this kitchen object from the parent, so the parent knows it no longer has a kitchen object
        Destroy(gameObject);
    }

    public bool TryGetPlate (out PlateKitchenObject plateKitchenObject) // checks if the kitchen object is a plate, and if so, outputs the plate kitchen object reference
    {
        if(this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public static KitchenObject SpawnKitchenObject (KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab); //spawns in a prefab of object on interact
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent); //sets the parent of the new kitchen object to be the counter that spawned it, so it appears on the counter and the counter knows it has a kitchen object
        return kitchenObject;
    }

}
