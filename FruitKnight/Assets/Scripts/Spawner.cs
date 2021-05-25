using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] shapes;

    public float startTimeBtwSpawns=3;
    float timeBtwSpawns;

    [Header("Start Velocities")]
    public float XminStartVelocity = -5;
    public float XmaxStartVelocity = 5;
    [Space]
    public float YminStartVelocity = 50;
    public float YmaxStartVelocity = 500;
    [Space]
    public float ZminStartVelocity = -5;
    public float ZmaxStartVelocity = 5;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    // Update is called once per frame
    void Update()
    {
        timeBtwSpawns -= Time.deltaTime;
        if(timeBtwSpawns <= 0)
        {
            timeBtwSpawns = startTimeBtwSpawns;

            SummonObject();
        }
    }

    void SummonObject()
    {
        startTimeBtwSpawns *= 0.99f;
        GameObject curOBJ = Instantiate(shapes[Random.Range(0, shapes.Length)], transform.position, Quaternion.identity);
        curOBJ.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(XminStartVelocity, XmaxStartVelocity+1), Random.Range(YminStartVelocity, YmaxStartVelocity+1), Random.Range(ZminStartVelocity, ZmaxStartVelocity+1));
    }
}
