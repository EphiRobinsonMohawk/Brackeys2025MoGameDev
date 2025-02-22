using UnityEngine;

public class LightManager : MonoBehaviour 
{
    public Light fireLight;
    public GameManager gameManager;
    public void Start()
    {
        fireLight.intensity = 250;
    }

    public void Update()
    {
        if(GameManager.darkness >= 0 & GameManager.darkness <= 33 )
        {
            fireLight.intensity = 250;
            fireLight.range = 100;
        }
        if (GameManager.darkness >= 36 & GameManager.darkness <= 66)
        {
            fireLight.intensity = 150;
            fireLight.range = 66;
        }
        if (GameManager.darkness >= 67 & GameManager.darkness <= 99)
        {
            fireLight.intensity = 50;
            fireLight.range = 33;
        }
        else if(GameManager.darkness >=100 )
        {
            fireLight.intensity = 0;
            fireLight.range = 0;
            
            gameManager.LoseGame();
        }
    }

}
