using Unity.VisualScripting;
using UnityEngine;

public class ResetGameOnClick : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GameManager.StartGame();
    }
}
