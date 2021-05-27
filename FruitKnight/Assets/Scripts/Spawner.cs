using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] shapes; // list of shapes the spawner can spawn

    public float startTimeBtwSpawns = 3;
    float timeBtwSpawns; // current time before another shape

    [Header("Start Velocities")]
    public float XminStartVelocity = -0.2f;
    public float XmaxStartVelocity = 0.2f;
    [Space]
    public float YminStartVelocity = 7;
    public float YmaxStartVelocity = 10;
    [Space]
    public float ZminStartVelocity = -0.2f;
    public float ZmaxStartVelocity = -2;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns; // reset time at start
    }
    void Update()
    {
        timeBtwSpawns -= Time.deltaTime; // remove time from timer
        if(timeBtwSpawns <= 0)
        {
            timeBtwSpawns = startTimeBtwSpawns;

            SummonObject();
        }
    }
    void SummonObject()
    {
        startTimeBtwSpawns *= 0.99f; // shorten time btw spawns to make game harder over time
        GameObject curOBJ = Instantiate(shapes[Random.Range(0, shapes.Length)], transform.position, Quaternion.identity); // summon object
        curOBJ.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(XminStartVelocity, XmaxStartVelocity+1), Random.Range(YminStartVelocity, YmaxStartVelocity+1), Random.Range(ZminStartVelocity, ZmaxStartVelocity+1)); // make it go in a random direction
    }
}
