using UnityEngine;

public class SliderValue : MonoBehaviour
{
    public bool Insanity;
    public bool Hunger;
    public bool Progress;

    void Update()
    {
        if (Insanity)
        {
            GetComponent<UnityEngine.UI.Slider>().value = GameManager.insanity;
        }
        else if (Hunger)
        {
            GetComponent<UnityEngine.UI.Slider>().value = GameManager.hunger;
        }
        else if (Progress)
        {
            GetComponent<UnityEngine.UI.Slider>().value = GameManager.bookProgress;
        }
    }
}