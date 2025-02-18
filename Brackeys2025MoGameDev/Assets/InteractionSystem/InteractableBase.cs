using UnityEngine;

public class InteractableBase : MonoBehaviour, IIntercatable
{
    [Header("Interactable Settings")]
    public float holdDuration;

    public bool holdInteract;
    public bool multipleUse;
    public bool isInteractable;

    public float HoldDuration => holdDuration;
    public bool HoldInteract => holdInteract;
    public bool MultipleUse => multipleUse;
    public bool IsInteractable => isInteractable;

    public virtual void OnInteract()
    {
        Debug.Log("INTERACTED " + gameObject.name);
    }
    
}
