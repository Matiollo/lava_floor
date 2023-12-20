using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public void TurnOffGame() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Gameplay");
    }
}
