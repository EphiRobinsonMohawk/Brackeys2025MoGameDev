using UnityEngine;

public class ConsumeInteractable : InteractableBase
{
    public override void OnInteract()
    {
        base.OnInteract();
        //add logic under this comment. when complete attach script to desired object. be sure to set layer to interactable.
        //code goes here
        GameManager.Eat();
        Destroy(gameObject);
    }
}
