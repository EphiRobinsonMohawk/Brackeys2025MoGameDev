using UnityEngine;

public class ChopInteractable : InteractableBase
{
    public Animator animator;
    public override void OnInteract()
    {
        base.OnInteract();
        //add logic under this comment. when complete attach script to desired object. be sure to set layer to interactable.
        //code goes here


        
        if (GameManager.logsHeld > 0)
        {
            animator.SetTrigger("ChopInteract");
            GameManager.Chop();
            Debug.Log("I have " + GameManager.logsHeld + " logs!");
            Debug.Log("I have " + GameManager.sticksHeld + "sticks!");
            Debug.Log("I have " + GameManager.hunger + " hunger!");
        }
        else
        {
            Debug.Log("I have " + GameManager.logsHeld + " logs!");
            Debug.Log("I have no logs!");
            //display i have no logs dialogue
        }
    
}
}
