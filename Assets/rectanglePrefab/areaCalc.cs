using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaCalc : MonoBehaviour
{

    public float area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        area = transform.localScale.x * transform.localScale.y;
    }
}
