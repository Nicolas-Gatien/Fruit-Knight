using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape : MonoBehaviour
{
    public bool sliced; // used to see if the object has been cut at all
    public bool cut; // used to make sure if you hit the same shape with 2 swords at the same time, it doesn't summon double the amount of shapes

    public int score = 5; // base score at a full size
    public float size = 1; // base start size

    public float sizeDivider = 2; // how much should the size of the shape be divided by every time a player slices it
    public int scoreMultiplier = 2; // how many more points should a player get for slicing smaller cubes

    void Start()
    {
        GetComponent<Rigidbody>().mass = size; // assign objects mass equal to it's size
        cut = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size, size, size); // reset size

        if (size < 0.125f) // destroy the game object if it gets too small to slice
        {
            MinSizeReached();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword")) // check if we collide with an object with a sword tag
        {
            if (cut == false) // check if it's been cut before? This stops it from summoning more shapes than it should
            {
                other.GetComponent<Sword>().PlaySliceSound(); // play the sound from the sword script
                Sliced();
            }
            cut = true;
        }
        else if (other.CompareTag("Die")) // check if we collide with an object with a die tag
        {
            if (sliced == true) // if the cube has been cut at all, then nothing happens and we can just destroy the cube
            {
                MinSizeReached();
            }
            else // if not, the player has missed a cube, and must restart the level
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Sliced()
    {
        sliced = true;
        ScoreManager.score += score; // add score
        GameObject offcut1 = Instantiate(this.gameObject, transform.position, Quaternion.identity); // create smaller versions
        SetOffcutVariables(offcut1); // set variables
        GameObject offcut2 = Instantiate(this.gameObject, transform.position, Quaternion.identity); // repeat
        SetOffcutVariables(offcut2);
        Destroy(this.gameObject);
    }

    void SetOffcutVariables(GameObject offcut) // apply all the multipliers
    {
        offcut.GetComponent<Shape>().size = size / sizeDivider;
        offcut.GetComponent<Shape>().score *= scoreMultiplier;
        offcut.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1 + 1), Random.Range(3, 7 + 1), Random.Range(-1, 1 + 1)); // makes the offcuts go in a slightly random direction
        offcut.GetComponent<Shape>().sliced = true;
    }

    void MinSizeReached()
    {
        Destroy(this.gameObject);
    }
}