using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUIPanel : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI tooltipText;

    public void SetTooltip(string tooltip)
    {
        tooltipText.SetText(tooltip);

    }

    public void UpdateProgressBar(float fillAmount)
    {
        progressBar.fillAmount = fillAmount;
    }

    public void ResetUI()
    {
        progressBar.fillAmount = 0f;
        tooltipText.SetText("");
    }
    
    
}
