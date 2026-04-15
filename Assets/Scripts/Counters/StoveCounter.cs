using System.Collections;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter
{
    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    /*private void Start() //couroutine stuff
    {
        StartCoroutine(HandleFryTimer());
    }
    private IEnumerator HandleFryTimer(){
        yield return new WaitForSeconds(1f);
    }*/
    private State state;
    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:


                    fryingTimer += Time.deltaTime; //if there is something on the stove, start the timer

                    if (fryingTimer > fryingRecipeSO.fryingTimerMax)
                    {
                        //Fried the object

                        GetKitchenObject().DestroySelf(); //destroy the object on the stove

                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this); //spawn the output of the recipe on the stove

                        state = State.Fried; //change state to fried
                    }

                    break;
                case State.Fried:
                    break;
                case State.Burned:
                    break;
            }
        }

    }
    public override void Interact (Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                //player is carrying something that can be fried
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this); //if player is carrying something, then put it on the counter and set parent to counter

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO()); //get the recipe for the object on the stove

                    state = State.Frying;
                    fryingTimer = 0f; //reset the timer
                }
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

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO); //if there is a recipe for the input, return true
        return fryingRecipeSO != null; //if there is a recipe for the input, return true, if not, return false

    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null) //if there is a recipe for the input, return the output
        {
            return fryingRecipeSO.output; //return the output of the recipe
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray) //scrolls through list to find the correct output for the input
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO) //if array input matches the object we have, give the output
            {
                return fryingRecipeSO; //return the recipe that matches the input
            }
        }
        return null;


    }

}
