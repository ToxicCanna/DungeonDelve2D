using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleExit : MonoBehaviour
{
    PlayerController playerController;

    public void ExitBattle()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
