using UnityEngine;

public interface IIntercatable
{
    float HoldDuration { get; }
    bool HoldInteract { get; }
    bool MultipleUse { get; }
    bool IsInteractable { get; }

    string TooltipMessage { get; }


    void OnInteract();
}
