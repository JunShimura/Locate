using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mover : MonoBehaviour
{
    [SerializeField] float a = 1;
    [SerializeField] float b = 0;
    [SerializeField] float c = 1;
    [SerializeField] float d = 0;
    [SerializeField] float e = 0;
    [SerializeField] float f = 0;

    [SerializeField] Transform[] targets;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed");
            foreach (Transform target in targets)
            {
                Vector3 pos = target.position;
                pos.x = a * pos.x + b * pos.y + c;  //x'=ax+by+c
                pos.y = d * pos.x + e * pos.y + f;  //y'=dx+ey+f
                target.position = pos;
            }
        }
    }


}
