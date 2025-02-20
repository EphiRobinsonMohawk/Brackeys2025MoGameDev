
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("Data")]
    public InteractionInputData interactionInputData;
    public InteractionData interactionData;

    [Space, Header("UI")]
    [SerializeField] private InteractionUIPanel uiPanel;

    [Space]
    [Header("Ray Settings"),]
    public float rayDistance;
    public float raySphereRadius;
    public LayerMask interactableLayer;

    private Camera cam;

    private bool interacting;
    public  float holdTimer = 0f;
    float holdPercent;

    private void Awake()
    {
        cam = FindFirstObjectByType<Camera>();
    }


    private void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;

        bool didHit = Physics.SphereCast(ray, raySphereRadius, out hitInfo, rayDistance, interactableLayer);
        if (didHit)
        {
            InteractableBase interactable = hitInfo.transform.GetComponent<InteractableBase>();

            if(interactable != null)
            {
                if(interactionData.IsEmpty())
                {
                    interactionData.Interactable = interactable;
                    uiPanel.SetTooltip(interactable.TooltipMessage);
                }
                else
                {
                    if (!interactionData.IsSameInteractable(interactable))
                    {
                        interactionData.Interactable = interactable;
                        uiPanel.SetTooltip(interactable.TooltipMessage);
                    }
                       
                        
                }
            }
        }
        else
        {
            uiPanel.ResetUI();
            interactionData.ResetData();
        }

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, didHit ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        if(interactionData.IsEmpty())
        {
            return;
        }
        if(interactionInputData.InteractedClicked)
        {
            interacting = true;
            holdTimer = 0f;
        }
        if(interactionInputData.InteractedRelease)
        {
            interacting = false;
            holdTimer = 0f;
            uiPanel.UpdateProgressBar(0f);
        }
        if(interacting)
        {
            if(!interactionData.Interactable.IsInteractable)
            {
                return;
            }
            if(interactionData.Interactable.HoldInteract)
            {
                holdTimer += Time.deltaTime;
                holdPercent = holdTimer / interactionData.Interactable.HoldDuration;
                            
                uiPanel.UpdateProgressBar(holdPercent);
                if(holdTimer >= interactionData.Interactable.HoldDuration)
                {
                    interactionData.Interact();
                    interacting = false;
                }

            }
            else
            {
                interactionData.Interact();
                interacting = false;
            }
        }
    }
}
