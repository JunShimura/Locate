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
            var newPos = pos;
            var r = Mathf.Deg2Rad * a;  //ƒ‰ƒWƒAƒ“’l‚É•ÏŠ·
            newPos.x = pos.x * Mathf.Cos(r) - pos.y * Mathf.Sin(r);
            newPos.y = pos.x * Mathf.Sin(r) + pos.y * Mathf.Cos(r);
            transform.position = newPos;
        }
    }


}
