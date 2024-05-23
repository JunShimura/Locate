using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstance : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField][Header("•ªŠ„”")] uint divide = 10;
    [SerializeField][Header("‰Šú‚Ì”¼Œa")] float r1 = 5;  //‰Šú‚Ì”¼Œa
    [SerializeField][Header("ÅŒã‚Ì”¼Œa")] float r2 = 0;
    [SerializeField][Header("ü‰ñ”")] float r3 = 0;
    [SerializeField][Header("[‚³")] float depth = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < divide * r3; i++)
        {
            float t = Mathf.PI * 2 * i / divide;
            float posX = Mathf.Sin(t) * (r1 + r2 * i / (divide * r3));
            float posY = Mathf.Cos(t) * (r1 + r2 * i / (divide * r3));
            float posZ = depth * i / (divide * r3);
            Vector3 pos = new Vector3(posX, posY, posZ);
            GameObject.Instantiate(target, pos, Quaternion.identity);
        }

    }
}
