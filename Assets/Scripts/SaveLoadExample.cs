using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadExample : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.HasKey("playerpos_x");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("id", 345);
        PlayerPrefs.SetFloat("value", 34.56f);
        PlayerPrefs.SetString("name", "killian");

        PlayerPrefs.SetFloat("playerPos_x", playerTransform.position.x);
        PlayerPrefs.SetFloat("playerPos_y", playerTransform.position.y);
        PlayerPrefs.SetFloat("playerPos_y", playerTransform.position.z);

        Debug.Log("player position saved");
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("id"))
        {
            Debug.Log("id is " + PlayerPrefs.GetInt("id"));
        }
        else
        {
            Debug.Log("No such ID exists");
        }


        Vector2 playerPosition = new Vector2(PlayerPrefs.GetFloat("playerPos_x"), PlayerPrefs.GetFloat("playerPos_y"));
        playerPosition = playerPosition;


    }
}
