using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] float a = 1;
    [SerializeField] float b = 0;
    [SerializeField] float c = 1;
    [SerializeField] float d = 0;
    [SerializeField] float e = 0;
    [SerializeField] float f = 0;

    [SerializeField] Transform[] targets;

    private LineRenderer lineRenderer;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        SetLine();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed");
            foreach (Transform target in targets)
            {
                Vector3 pos = target.position;
                Vector3 newPos = new Vector3();
                newPos.x = a * pos.x + b * pos.y + c;  //x'=ax+by+c
                newPos.y = d * pos.x + e * pos.y + f;  //y'=dx+ey+f
                //float r = Mathf.PI / 4.0f;
                //newPos.x = Mathf.Cos(r) * pos.x - Mathf.Sin(r) * pos.y + c;  //x'=ax+by+c
                //newPos.y = Mathf.Sin(r) * pos.x + Mathf.Cos(r) * pos.y + f;  //y'=dx+ey+f
                target.position = newPos;
            }
            SetLine();
            textMeshProUGUI.text = "x'=" + a.ToString("F3") + "x+" + b.ToString("F3") + "y+" + c.ToString("F3")
                + "\ny'=" + d.ToString("F3") + "x+" + e.ToString("F3") + "y+" + f.ToString("F3");
        }
    }
    void SetLine()
    {
        lineRenderer.positionCount = targets.Length;
        for (var i = 0; i < targets.Length; i++)
        {
            lineRenderer.SetPosition(i, targets[i].position);
        }
    }


}
