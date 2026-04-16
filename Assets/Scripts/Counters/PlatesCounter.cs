using System;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;
    private float spawnPlaterTimerMax = 4f;
    private int platesSpawnedAmount;
    private int plateSpawnedAmountMax = 4;
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlaterTimerMax)
        {
            spawnPlateTimer = 0f;
            

            if (platesSpawnedAmount < plateSpawnedAmountMax) //if less plates then max
            {
                platesSpawnedAmount++; //add plate

                OnPlateSpawned?.Invoke(this, EventArgs.Empty); //fire plate spawned event
            }
        }
    }
    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject()) //if player got nadda
        {
            //Player empty handed
            if(platesSpawnedAmount > 0) //more than one plate
            {
                //At least one plate spawned
                platesSpawnedAmount--; //remove plate

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player); //spawn plate on player

                OnPlateRemoved?.Invoke(this, EventArgs.Empty); //fire off the remove plate event
            }
        }
    }
}



