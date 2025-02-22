using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
// made most things static, so I can refrence the gameManager for our interactables. -trav
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GameObject lossUI;
    public GameObject winUI;

    public static AudioManager audioManager;


    // Resources
    public static float logsHeld = 0f;
    public static float sticksHeld = 0f;

    // All counts are out of 100
    public static float insanity = 0f;
    public static float hunger = 50f;
    public static float darkness = 0f;
    public static float bookProgress = 0f;


    // Rates at which insanity, hunger, and darkness increase
    float insanityTimeRate = 0.2f;
    float hungerTimeRate = 0.5f;
    float darknessTimeRate = 1f;

    // Amounts to increase or decrease counts by
    public static float readingInsanityAmount = 10;
    public static float eatingHungerAmount = 10;
    public static float addingToFireDarknessAmount = 10;

    public static bool reading = false;

    //grabbing interaction input data
    public static InteractionInputData interactionInputData;

    //making an animator
    public Animator animator;


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
        // load audio
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Update()
    {
        PassTime();
        Debug.Log(+darkness + " darkness");
        Debug.Log(+hunger + " hunger");
        Debug.Log(+insanity + " insanity");
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
        logsHeld = 0;
        insanity = 0;
        hunger = 100;
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
    public void PassTime()
    {
        // Increase hunger and insanity
        hunger -= Time.deltaTime * hungerTimeRate;
        insanity += Time.deltaTime * insanityTimeRate;
        darkness += Time.deltaTime * darknessTimeRate;

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
            gameManager.WinGame();
        }
        if (insanity >= 100)
        {
            gameManager.LoseGame();
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
    }

    public static void Chop()
    {
        hunger -= 15;
        logsHeld--;
        sticksHeld += 2;
        audioManager.PlaySFX(audioManager.chop);



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
