using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        // these are for testing purposes mainly, and will not be available to players

        if (Input.GetKeyDown(KeyCode.O)) // Save data
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.P)) // Load scene
        {
            LoadData();
        }

        if (Input.GetKeyDown(KeyCode.L)) // Load the player position
        {
            LoadPlayerPosition();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("playerPos_x", playerTransform.position.x);
        PlayerPrefs.SetFloat("playerPos_y", playerTransform.position.y);
        PlayerPrefs.SetFloat("playerPos_z", playerTransform.position.z);

        PlayerPrefs.SetString("sceneName", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save(); // Ensure data is saved

        Debug.Log("Player position and scene saved");
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("sceneName"))
        {
            string sceneName = PlayerPrefs.GetString("sceneName");

            // Load scene asynchronously
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("No saved scene name found in PlayerPrefs.");
        }
    }

    public void LoadPlayerPosition()
    {
        // Check if there is saved player position data
        if (PlayerPrefs.HasKey("playerPos_x") && PlayerPrefs.HasKey("playerPos_y") && PlayerPrefs.HasKey("playerPos_z"))
        {
            float x = PlayerPrefs.GetFloat("playerPos_x");
            float y = PlayerPrefs.GetFloat("playerPos_y");
            float z = PlayerPrefs.GetFloat("playerPos_z");

            playerTransform.position = new Vector3(x, y, z);

            Debug.Log("Player position loadedMAIN");
        }
        else
        {
            Debug.LogWarning("No saved player position found in PlayerPrefs.");
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    string GetSceneKeyPrefix(int sceneIndex)
    {
        // Use scene index as part of PlayerPrefs key prefix to ensure uniqueness per scene
        return "Scene" + sceneIndex.ToString() + "_";
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        string sceneKeyPrefix = GetSceneKeyPrefix(currentSceneIndex);

        // Check if there is saved player position data
        if (PlayerPrefs.HasKey("playerPos_x") && PlayerPrefs.HasKey("playerPos_y") && PlayerPrefs.HasKey("playerPos_z"))
        {
            float x = PlayerPrefs.GetFloat("playerPos_x");
            float y = PlayerPrefs.GetFloat("playerPos_y");
            float z = PlayerPrefs.GetFloat("playerPos_z");

            playerTransform.position = new Vector3(x, y, z);

            Debug.Log("Player position loaded");
        }
        else
        {
            Debug.LogWarning("No saved player position found in PlayerPrefs.");
        }
    }
}