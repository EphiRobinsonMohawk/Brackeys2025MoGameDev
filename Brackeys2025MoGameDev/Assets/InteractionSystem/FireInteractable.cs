using UnityEngine;

public class FireInteractable : InteractableBase
{
    public override void OnInteract()
    {
        base.OnInteract();
        //add logic under this comment. when complete attach script to desired object. be sure to set layer to interactable.
        //code goes here
        if (GameManager.sticksHeld > 0)
        {
            GameManager.AddToFire();
            Debug.Log("I have " + GameManager.sticksHeld);
        }
        else 
        {
            Debug.Log("I have no sticks");
        }
    }
}
