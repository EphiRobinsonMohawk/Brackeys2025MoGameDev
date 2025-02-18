using UnityEngine;

[CreateAssetMenu(fileName = "InteractionData", menuName = "InteractionSystem/InteractionData")]
public class InteractionData : ScriptableObject
{
    private InteractableBase interactable;
    public InteractableBase Interactable
    {
        get => interactable;
        set => interactable = value;
    }    

    public void Interact()
    {
        interactable.OnInteract();
        ResetData();
    }

    public bool IsSameInteractable(InteractableBase _newInteractable)
    {
        return interactable == _newInteractable;
    }
    public bool IsEmpty() => interactable == null;
    public void ResetData()
    {
        interactable = null;
    }
    
}
