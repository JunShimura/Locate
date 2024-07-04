using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceControl : MonoBehaviour
{
    [SerializeField]
    Vector3 speed = Vector3.right;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var f = new Vector3(
                Input.GetAxisRaw("Horizontal")*speed.x,
                0,
                Input.GetAxisRaw("Vertical") *speed.z
               )
            * Time.deltaTime;
        rb.AddForce(f);
    }
}
