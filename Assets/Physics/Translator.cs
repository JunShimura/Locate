using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField]
    Vector3 speed = Vector3.right; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime);
        // var pos= transform.position;
        // pos += speed * Time.deltaTime;
        // transform.position = pos;
    }
}
