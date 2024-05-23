using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstance : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] uint divide = 10;
    [SerializeField] uint r1 = 5;
    [SerializeField] float r2 = 0;
    [SerializeField] float r3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < divide*r3; i++)
        {
            float t = Mathf.PI * 2 * i / divide;
            float posX = Mathf.Sin(t) * (r1 + r2 * i);
            float posY = Mathf.Cos(t) * (r1 + r2 * i);
            Vector3 pos = new Vector3(posX, posY, 0);
            GameObject.Instantiate(target, pos, Quaternion.identity);
        }

    }
}
