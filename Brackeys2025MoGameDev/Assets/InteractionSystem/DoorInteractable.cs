using UnityEngine;

public class DoorInteractable : InteractableBase
{
    bool doorOpen = false;
    public Animator animator;
    public override void OnInteract()
    {
        base.OnInteract();
        //add logic under this comment. when complete attach script to desired object. be sure to set layer to interactable.
        //code goes here
        if(doorOpen == false)
        {
            animator.SetTrigger("openDoor");
            doorOpen = true;
        }
        else 
        {
            animator.SetTrigger("closeDoor");
            doorOpen = false;
        }
    }
}
