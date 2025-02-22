using UnityEngine;
using UnityEngine.UIElements;

public class InsanityVisualizer : MonoBehaviour
{

    public GameObject content;
    public GameObject worried;
    public GameObject insane;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.insanity > 70)
        {
            insane.SetActive(true);
            content.SetActive(false);
            worried.SetActive(false);
        }
        else if (GameManager.insanity > 30)
        {
            worried.SetActive(true);
            content.SetActive(false);
            insane.SetActive(false);
        }
        else
        {
            worried.SetActive(false);
            insane.SetActive(false);
            content.SetActive(true);
        }
    }
}
