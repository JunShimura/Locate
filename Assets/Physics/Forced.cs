using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Forced : MonoBehaviour
{
    [SerializeField]
    Vector3 speed = Vector3.right;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = speed;   
    }
}
