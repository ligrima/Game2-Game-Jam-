using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    // This will return the player to the mainscene
    public void NewGame ()
    {
        SceneManager.LoadScene("Game");
    }
	
}
