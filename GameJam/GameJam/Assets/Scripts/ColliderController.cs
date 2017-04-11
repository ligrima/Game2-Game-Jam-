using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{

    // this is the player score
    public int score = 0;

    //this is the canvas text box
    public Text scoreText;

    // this variable gives us the number of spheres in the scene
    protected int numOfGoodObj;

    // when the script launches, get the number if spheres
    void Start()
    {
        numOfGoodObj = GameObject.FindGameObjectsWithTag("GoodObj").Length;
    }
    // when the capsule hits a sphere with a trigger collider, do something
    void OnTriggerEnter2D (Collider2D c)
    {

        // check that the player has hit a sphere
        if (c.tag == "GoodObj")
        {

            // increment the score when the capsule hits the sphere
            score += 1;

            // adjust the score on the canvas
            scoreText.text = "Score: " + score;

            //disable the collider so it doesnt repeat
            c.enabled = false;

            // destroy the sphere so we can't hit it a second time
            Destroy(c.gameObject);

            // show us the score in the console
            // Ctrl + Shift + C in Unity
            Debug.Log(score);

            // check that the score is the same as the number of spheres, and end the game
            if (score == numOfGoodObj)
            {
                SceneManager.LoadScene("YouWin Scene");
            }
        }
        else
        {

            // if the player hits anything that is not the sphere, show the game over screen
            SceneManager.LoadScene("GameOver Scene");

            // in order to load a new scene in Unity, we need to set it up inb the Build Settings
        }
    }
}
