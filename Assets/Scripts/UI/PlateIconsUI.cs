using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject; //reference to the plate kitchen object 
    [SerializeField] private Transform iconTemplate; //reference to the icon template


    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false); //hide the icon template
    }

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded; //sub to event
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) //event wheen an ingredient is added to the plate
    {
        UpdateVisual(); //update the visual of the plate icons
    }

    private void UpdateVisual()
    {
        foreach(Transform child in transform)
        {
            if (child == iconTemplate) continue; //skip the icon template
            Destroy(child.gameObject);
        }
        
        foreach(KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
