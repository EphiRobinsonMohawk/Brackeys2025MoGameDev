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
            Debug.Log("Slider Value: " + GetComponent<UnityEngine.UI.Slider>().value);
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