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
        content.SetActive(false);
        worried.SetActive(false);
        insane.SetActive(false);

        if (GameManager.insanity > 70)
            insane.SetActive(true);
        else if (GameManager.insanity > 30)
            worried.SetActive(true);
        else
            content.SetActive(true);
    }
}
