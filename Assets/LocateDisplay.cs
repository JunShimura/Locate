using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocateDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private Vector3 displayedPosition;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(displayedPosition != transform.position) {
            UpdateDisplay();
        }
    }
    void UpdateDisplay()
    {
        displayedPosition = transform.position;
        textMeshProUGUI.text = displayedPosition.ToString();
    }
}
