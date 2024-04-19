using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float a = 1;
    [SerializeField] float b = 0;
    [SerializeField] float c = 1;
    [SerializeField] float d = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = transform.position;
            pos.x = a * pos.x + b;  //x'=ax+b
            pos.y = c * pos.y + d;  //y'=cy+d
            transform.position = pos;
        }
    }


}
