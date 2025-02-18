using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]


public class InteractionInputData : ScriptableObject
{
    private bool interactedClicked;
    private bool interactedRelease;

    public bool InteractedClicked
    {
        get => interactedClicked;
        set => interactedClicked = value;
    }

    public bool InteractedRelease
    {
        get => interactedRelease;
        set => interactedRelease = value;
    }

    public void Reset()
    {
        interactedClicked = false;
        interactedRelease = false;
    }
}
