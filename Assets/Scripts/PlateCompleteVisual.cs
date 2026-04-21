using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public struct KitchenObjectSO_GameObject //struct is a data structure that can hold multiple variables, in this case it holds a reference to the kitchen object scriptable object and the game object that represents it in the scene
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    [SerializeField] PlateKitchenObject plateKitchenObject; //reference to the plate kitchen object
    [SerializeField] private List <KitchenObjectSO_GameObject> kitchenObjectSO_GameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded; //sub to event
        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList) //loop through the list of kitchen object scriptable objects and game objects
        {    
                kitchenObjectSOGameObject.gameObject.SetActive(false); //dont show at start
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach(KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList) //loop through the list of kitchen object scriptable objects and game objects
        {
            if(kitchenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO) //if list scrolling hits whats on ingredient
            {
                kitchenObjectSOGameObject.gameObject.SetActive(true); //if the kitchen object scriptable object matches the one that was added to the plate, set the corresponding game object to active
            }
        }
    }
}
