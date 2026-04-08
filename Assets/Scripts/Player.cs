using UnityEngine;
using System;


public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; } //singleton for player you're able to reference it anywhere and only one can exist, if you try to make another one it will give you an error in the console

    public event EventHandler <OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged; //<> means youll need this when you call the event handler, the event handler is called when we select a counter and it will pass the counter we selected to whatever is listening to the event handler
    public class OnSelectedCounterChangedEventArgs : EventArgs //makes a class of info we can use when we call the event handler, in this case it is the counter we selected
    {
        public BaseCounter selectedCounter; //the counter we are looking at
    }

    [SerializeField]private float moveSpeed = 7f; //movement speed
    [SerializeField]private GameInput gameInput; //refers to the Game Input
    [SerializeField]private LayerMask countersLayerMask; //layer mask for the raycast to hit the counters ONLY
    [SerializeField] private Transform kitchenObjectHoldPoint; //where the kitchen object will be on the counter

    private bool isWalking;
    private Vector3 lastInteractDir; //allows you to interact even if you are not pressing a movement key
    private BaseCounter selectedCounter;//Lets us access interact func i think?

    private KitchenObject kitchenObject;


    private void Awake()
    {
        if(Instance!= null)//checks for two players and gives an error if there are two players in the scene
        {
          Debug.LogError("There is more than one Player instance! ");
        }
        Instance = this; //if there is not then we set the instance to this player
    }
    private void Start() //start is called before the first frame update
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction; //subscribes to the event handler in GameInput for the interact "e"
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }
    private void GameInput_OnInteractAlternateAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)//if there is a counter selected then interact with it
        {
            selectedCounter.InteractAlternate(this);
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)//if there is a counter selected then interact with it
        {
            selectedCounter.Interact(this);
        }
    }
    
    private void Update()
    {
        HandleMovement(); //handles movement and animation
        HandleInteractions(); //handles raycast and interaction with counters
    }
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); //gets from GameInput
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //translates vector 2 to 3
        
        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask)) //layermask checks for one specific type of object to hit for
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter)) //if it hits the counter
            {
                //Has ClearCounter
                if (baseCounter != selectedCounter) //if clear counter is not the same as the one we have already selected then we select it and if it is the same we deselect it
                {
                    SetSelectedCounter(baseCounter);//if it is not the same we select the new one
                }
            }
            else
            {
                SetSelectedCounter(null);//if it hits something else then we deselect the counter
            }
        }
        else
        {
            SetSelectedCounter(null);//if it hits nothing then we deselect the counter
        }

    
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); //gets from GameInput
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //translates vector 2 to 3
        
        float moveDistance = moveSpeed * Time.deltaTime; //Set for the raycast how far it shoots
        float playerRadius = .7f;//Set for the raycast
        float playerHeight = 2f; //Set for the raycast
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance); //sets up hitbox as a bool

        if (!canMove) //tries to move in the direction we want to move, if it hits something then we try to move only on the x or z axis depending on which one is open
        {
            //cannot move towards moveDir

            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);//question mark means flipped bool if canMove is false it becomes true and if it is true it becomes false

            if (canMove)
            {
                //can move only on the X
                moveDir = moveDirX;
            } else
            {
                //Cannot move only on the X

                //Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
            canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance); //sets canMove back to origianl

                if (canMove) 
                {
                    //can move only on the Z
                    moveDir = moveDirZ;
                }else
                {
                    //cannot move anywhere else since y n/a
                }
            }

        }
        if(canMove){
        transform.position += moveDir * moveDistance; //if movement is available and not raycast hit an object add on the input to the posotion
        }
        
        isWalking = moveDir != Vector3.zero; // moving = true & not = false animation bs
        
        float rotateSpeed = 10f; //roation of player
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //rotation
    }

    private void SetSelectedCounter(BaseCounter selectedCounter)//()brackets mean basically you're gonna need this information, use it in the function
    {
        this.selectedCounter = selectedCounter;
        
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter//sets the event args to the counter we just selected
        });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;//sets the kitchen object on the counter to the kitchen object passed in
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
