using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    [SerializeField] float a = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x * Mathf.Cos(a / 180.0f) - pos.y * Mathf.Sin(a / 180.0f);
            pos.y = pos.x * Mathf.Sin(a / 180.0f) + pos.y * Mathf.Cos(a / 180.0f);
            transform.position = pos;
        }
    }


}
