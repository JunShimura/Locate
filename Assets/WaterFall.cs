using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFall : MonoBehaviour
{
    [SerializeField]
    float randomR = 1.0f;
    [SerializeField]
    GameObject waterDot;
    [SerializeField]
    float instantiateRatio = 2.0f;
    float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > instantiateRatio)
        {
            t = 0;
            var dot =GameObject.Instantiate(
                waterDot, 
                Random.onUnitSphere*randomR+transform.position,
                Quaternion.identity);
            dot.transform.SetParent(this.transform);
        }        
    }
}
