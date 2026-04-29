using UnityEngine;
using System.Collections.Generic;
using System;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeListSO recipeListSO; //reference all types of valid recipes

    private List<RecipeSO> waitingrecipeSOList; //list of recipes that are waiting to be delivered

    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f; //how often a new recipe should be spawned
    private int waitingRecipesMax = 4; //maximum number of waiting recipes at a time    

    private void Awake()
    {
        Instance = this;
        waitingrecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f) //if the timer is less than zero...
        {
            spawnRecipeTimer = spawnRecipeTimerMax; //reset timer

            if (waitingrecipeSOList.Count < waitingRecipesMax) //if we haven't reached the max number of waiting recipes...
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingrecipeSOList.Add(waitingRecipeSO); //add a random recipe to the waiting list

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty); //invoke the OnRecipeSpawned event
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingrecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingrecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count) //if the number of ingredients on the plate is the same as the number of ingredients in the recipe...
            {
                //has same number of ingredients
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    //cycle through all the ingredients in the recipe and check if they are on the plate
                    bool ingredientFound = false;   
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //cycle through all the ingredients in the recipe and check if they are on the plate
                        if(plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            //ingredient matches
                            ingredientFound = true;
                            break;
                        }
                    }
                    if(!ingredientFound)
                    {
                        //This Reicpe ingredient was not found on the plate
                        plateContentsMatchesRecipe = false;
                    }
                }
                if (plateContentsMatchesRecipe)
                {
                    //Player delivered the correct recipe
                    waitingrecipeSOList.RemoveAt(i); //remove the recipe from the waiting list

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty); //invoke the OnRecipeCompleted event
                    return;
                }
            }
        }
        //no matches found
        //player did not deliver a correct recipe
        Debug.Log("Player did not deliver the correct recipe");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingrecipeSOList;
    }

}
