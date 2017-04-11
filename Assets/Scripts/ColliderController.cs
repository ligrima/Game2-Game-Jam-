using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{

    // this is the player score
    public int score = 0;

    // this is the canvas text box
    public Text scoreText;

    // this variable gives us the number of good objects in the scene
    protected int numOfGoodObj;

    // when the script launches, get the number of spheres
    void Start()
    {
        // this gives us the number of good objects on the scene.
        numOfGoodObj = GameObject.FindGameObjectsWithTag("GoodObj").Length;
    }

    // when the player hits a good obejct with a trigger collider, do something
    void OnTriggerEnter2D (Collider2D c)
    {

        // check that the player has hit a good object
        if (c.tag == "GoodObj")
        {

            // increment the score when the player hits the good object
            score += 1;

        }
        else if (c.tag == "BadObj")
        {

            // increment the score when the player hits the bad object
            score -= 1;

        }

        // adjust the score on the canvas
        scoreText.text = "Score: " + score;

        // disabled the collider so it doesn't repeat
        c.enabled = false;

        // destroy the good object so we can't hit it a second time
        Destroy(c.gameObject);

        // show us the score in the console (Ctrl + Shift + C in Unity
        Debug.Log(score);
        //check that the score is the same as the number of good objects, and end the game.
        if (GameObject.FindGameObjectsWithTag("GoodObj").Length <= 1)
        {
            SceneManager.LoadScene("YouWin Scene");
        }

        //check that the score is the same as the number of good objects, and end the game.
        if (score <= 0)
        {
            SceneManager.LoadScene("GameOver Scene");
        }

    }


}
