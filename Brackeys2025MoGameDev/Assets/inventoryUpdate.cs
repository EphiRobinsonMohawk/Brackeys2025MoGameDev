using TMPro;
using UnityEngine;

public class inventoryUpdate : MonoBehaviour
{
    public TextMeshProUGUI stickText;
    public TextMeshProUGUI logText;

    void Update()
    {
        stickText.text = GameManager.sticksHeld.ToString();
        logText.text = GameManager.logsHeld.ToString();
    }
}
