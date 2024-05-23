using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    // Update is called once per frame
    void Update()
    {
        //float xDiff = transform.position.x - target.position.x;
        //float yDiff = transform.position.y - target.position.y;
        //float distance = (float)Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        float distance = Vector3.Distance(transform.position, target.position);
        textMeshProUGUI.text = $"distance={distance.ToString()}";
    }
}
