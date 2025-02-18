using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // All counts are out of 100
    float insanity = 0;
    float hunger = 0;
    float darkness = 0;

    // Rates at which insanity, hunger, and darkness increase
    float insanityTimeRate = 0.1f;
    float hungerTimeRate = 0.1f;
    float darknessTimeRate = 0.1f;

    // Amounts to increase or decrease counts by
    float readingInsanityAmount = 10;
    float eatingHungerAmount = 10;
    float addingToFireDarknessAmount = 10;

    // Scene managerment
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        // Reset all counts when starting a new game
        insanity = 0;
        hunger = 0;
        darkness = 0;
        SceneManager.LoadScene("Game");
    }

    public void LoseGame()
    { }

    public void WinGame()
    { }

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
        if (insanity >= 100)
        {
            LoseGame();
        }
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
        if (darkness >= 100)
        {
            LoseGame();
        }
    }
}
