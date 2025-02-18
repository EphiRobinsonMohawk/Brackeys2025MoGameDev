using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InteractionInputData interactionInputData;

    private void Start()
    {
        interactionInputData.Reset();

    }

    private void Update()
    {
        GetInteractionInputData();
    }

    private void GetInteractionInputData()
    {
        interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
        interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
    }

}
