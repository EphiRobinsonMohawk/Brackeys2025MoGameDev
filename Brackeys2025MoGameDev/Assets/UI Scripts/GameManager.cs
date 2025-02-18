using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GameObject lossUI;
    public GameObject winUI;

    // Resources
    public float wood = 0;
    public float food = 0;

    // All counts are out of 100
    public float insanity = 0;
    public float hunger = 0;
    public float darkness = 0;

    // Rates at which insanity, hunger, and darkness increase
    float insanityTimeRate = 0.1f;
    float hungerTimeRate = 0.1f;
    float darknessTimeRate = 0.1f;

    // Amounts to increase or decrease counts by
    float readingInsanityAmount = 10;
    float eatingHungerAmount = 10;
    float addingToFireDarknessAmount = 10;

    void Awake()
    {
        // Create a persistent game manager
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Scene managerment
    public void ReturnToMenu()
    {
        gameManager.lossUI.SetActive(false);
        gameManager.winUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        // Reset all counts when starting a new game
        wood = 0;
        food = 0;
        insanity = 0;
        hunger = 0;
        darkness = 0;
        SceneManager.LoadScene("Game");
    }

    public void LoseGame()
    { 
        gameManager.lossUI.SetActive(true);
    }

    public void WinGame()
    {
        gameManager.winUI.SetActive(true);
    }

    // Pass time in the game
    public void PassTime(float time)
    {
        // Increase hunger and insanity
        hunger += time * hungerTimeRate;
        insanity += time * insanityTimeRate;
        darkness += time * darknessTimeRate;

        // Check if the player has lost
        if (hunger >= 100 || insanity >= 100 || darkness >= 100)
        {
            LoseGame();
        }
    }

    public void Read()
    {
        insanity += readingInsanityAmount;
    }

    public void Eat()
    {
        hunger -= eatingHungerAmount;
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    public void AddToFire()
    {
        darkness -= addingToFireDarknessAmount;
    }

    public void CollectWood()
    {
        wood++;
    }

    public void CollectFood()
    {
        food++;
    }
}
