using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape : MonoBehaviour
{
    public bool sliced;
    public bool cut;

    public int score = 5;
    public float size = 1;

    public float sizeDivider = 2;
    public int scoreMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = size;
        cut = false;   
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale = new Vector3(size, size, size);

        if(size < 0.125f)
        {
            MinSizeReached();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            if(cut == false)
            {
                other.GetComponent<Sword>().VibrateController();
                Sliced();
            }
            cut = true;
        }
        else if(other.CompareTag("Die"))
        {
            if(sliced == true)
            {
                MinSizeReached();
            }else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Sliced()
    {

        sliced = true;
        ScoreManager.score += score;
        GameObject offcut1 = Instantiate(this.gameObject, transform.position, Quaternion.identity);
        SetOffcutVariables(offcut1);
        GameObject offcut2 = Instantiate(this.gameObject, transform.position, Quaternion.identity);
        SetOffcutVariables(offcut2);

        Destroy(this.gameObject);
    }

    void SetOffcutVariables(GameObject offcut)
    {
        offcut.GetComponent<Shape>().size = size / sizeDivider;
        offcut.GetComponent<Shape>().score *= scoreMultiplier;
        offcut.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1 + 1), Random.Range(3, 7 + 1), Random.Range(-1, 1 + 1));
        offcut.GetComponent<Shape>().sliced = true;
    }

    void MinSizeReached()
    {
        Destroy(this.gameObject);
    }
}
