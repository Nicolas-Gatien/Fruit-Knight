using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);
        }
    }
}
