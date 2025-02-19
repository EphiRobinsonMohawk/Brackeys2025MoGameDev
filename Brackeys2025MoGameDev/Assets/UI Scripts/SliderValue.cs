using UnityEngine;

public class SliderValue : MonoBehaviour
{
    public bool Insanity;
    public bool Hunger;

    void Update()
    {
        if (Insanity)
        {
            GetComponent<UnityEngine.UI.Slider>().value = GameManager.gameManager.insanity;
        }
        else if (Hunger)
        {
            GetComponent<UnityEngine.UI.Slider>().value = GameManager.gameManager.hunger;
        }
    }
}