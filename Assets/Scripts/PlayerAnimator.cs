using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  
    private Animator animator; //Refers to the animator
    private const string IS_WALKING = "IsWalking"; //I think this refers to the boolean value inside the animator
    [SerializeField] private Player player; //Refers to the player
    private void Awake()
    {
        animator = GetComponent<Animator>(); //Gets animator
    }
    private void Update()
    {
         animator.SetBool(IS_WALKING, player.IsWalking()); //checks if player is walking or not updated and plays animation based off
    }
}
