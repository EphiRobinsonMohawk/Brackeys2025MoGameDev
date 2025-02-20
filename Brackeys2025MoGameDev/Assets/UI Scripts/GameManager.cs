using UnityEngine;
using UnityEngine.SceneManagement;
// made most things static, so I can refrence the gameManager for our interactables. -trav
public class GameManager : MonoBehaviour
{
    // All counts are out of 100
    public static float insanity = 0f;
    public static float hunger = 50f;
    public static float darkness = 0f;
    public static float bookProgress = 0f;
    public static float logsHeld = 0f;
    public static float sticksHeld = 0f;

    // Rates at which insanity, hunger, and darkness increase
    float insanityTimeRate = 0.1f;
    float hungerTimeRate = 0.1f;
    float darknessTimeRate = 0.1f;

    // Amounts to increase or decrease counts by
    public static float readingInsanityAmount = 10;
    public static float eatingHungerAmount = 10;
    public static float addingToFireDarknessAmount = 10;

    public static bool reading = false;

    //grabbing interaction input data
    public  static InteractionInputData interactionInputData;

    //making an animator
    public Animator animator;


    // Scene managerment
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        // Reset all counts when starting a new game
        insanity = 0;
        hunger = 100;
        darkness = 0;
        SceneManager.LoadScene("Game");
    }

    public static void LoseGame()
    { }

    public static void WinGame()
    { }

    // Pass time in the game
    public void PassTime(float time)
    {
        // Increase hunger and insanity
        hunger -= time * hungerTimeRate;
        insanity += time * insanityTimeRate;
        darkness += time * darknessTimeRate;

        // Check if the player has lost
        if (hunger <= 0 || insanity >= 100 || darkness >= 100)
        {
            LoseGame();
        }
    }

    public static void Read()
    {

        bookProgress += 1;
        insanity += readingInsanityAmount;
        Debug.Log("progress " + bookProgress + " insanity" + insanity);
        if (bookProgress >= 10)
        {
            GameManager.WinGame();
        }
        if (insanity >= 100)
        {
            GameManager.LoseGame();
        }
    }

    public static void Eat()
    {
        hunger += eatingHungerAmount;
        Debug.Log("Hunger" + hunger);
        if (hunger > 100)
        {
            hunger = 100;
        }
    }

    public static void AddToFire()
    {
        darkness -= addingToFireDarknessAmount;
        sticksHeld -= 1;
        if (darkness >= 100)
        {
            LoseGame();
        }
    }

   public static void Chop()
    {
        hunger -= 15;
        logsHeld--;
        sticksHeld += 2;

    }

    public static void PickupLog()
    {
        if (logsHeld >= 1)
        {
            // say I cannot carry more logs
            Debug.Log("I have " + GameManager.logsHeld + " logs!");
            Debug.Log("I cannot carry more logs!");
        }
        else
        {
            logsHeld++;
            Debug.Log("I have " + GameManager.logsHeld + " logs!");
        }
    }

}
