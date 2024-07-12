using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterLogic : MonoBehaviour
{
    public static EncounterLogic instance; // Singleton instance

    public int stepsTaken = 0;
    public int encounterThreshold = 5; // Minimum steps before checking for encounter
    public int maxStepsUntilEncounter = 50; // Maximum steps until next encounter
    public int minStepsUntilEncounter = 5; // Minimum steps until next encounter

    PlayerController playerController;

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        // Initialize steps taken
        stepsTaken = 0;

        // Start the first encounter check
        CheckEncounter();
    }

    // Call this method whenever the player takes a step
    public void IncrementSteps()
    {
        stepsTaken++;
        CheckEncounter();
    }

    // Method to check if an encounter should occur
    void CheckEncounter()
    {
        if (stepsTaken >= encounterThreshold)
        {
            int stepsUntilNextEncounter = Random.Range(minStepsUntilEncounter, maxStepsUntilEncounter + 1);
            if (stepsTaken >= stepsUntilNextEncounter)
            {
                TriggerRandomEncounter();
                // Reset steps taken
                stepsTaken = 0;
            }
        }
    }

    // Method to trigger a random encounter
    void TriggerRandomEncounter()
    {
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader != null)
        {
            sceneLoader.SaveData();
        }
        else
        {
            Debug.LogWarning("sceneLoader not found in the scene. Data not saved.");
        }
        // Logic to handle your encounter here, e.g., loading a battle scene
        Debug.Log("Random encounter triggered!");

        //Load battle scene
        SceneManager.LoadScene("BattleScene");
    }
}