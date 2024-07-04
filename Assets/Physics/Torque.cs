using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    [SerializeField]
    Vector3 speed = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity=speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
