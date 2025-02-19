using UnityEngine;

public class InteractableBase : MonoBehaviour, IIntercatable
{
    [Header("Interactable Settings")]
    [SerializeField] public float holdDuration = 1f;

    [SerializeField] public bool holdInteract = true;
    [SerializeField] public bool multipleUse = false;
    [SerializeField] public bool isInteractable = true;
    [SerializeField] private string tooltipMessage = "Interact";

    public float HoldDuration => holdDuration;
    public bool HoldInteract => holdInteract;
    public bool MultipleUse => multipleUse;
    public bool IsInteractable => isInteractable;

    public string TooltipMessage => tooltipMessage;

    public virtual void OnInteract()
    {
        Debug.Log("INTERACTED " + gameObject.name);
    }
    
}
