using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    // This will return the player to the main scene
    public void NewGame()
    {

        SceneManager.LoadScene("Game2");

    }
}
