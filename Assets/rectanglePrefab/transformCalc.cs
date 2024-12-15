using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformCalc : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private int iteration;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;
        lineGen lineGenerator = GetComponentInParent<lineGen>();
        meshGen rectangleGenerator = GetComponentInParent<meshGen>();
        iteration = iterationPicker();
        Debug.Log("best iteration for this rectangle is " + iteration);
        
    }

    // Update is called once per frame
    void Update()
    {
        lineGen lineGenerator = GetComponentInParent<lineGen>();
        LineRenderer lineRenderer = GetComponentInParent<LineRenderer>();
        transform.localScale = new Vector3(initialScale.x, lineRenderer.GetPosition(iteration).y, initialScale.z);
        transform.position = new Vector3(initialPosition.x, lineRenderer.GetPosition(iteration).y/2, initialPosition.z);

    }

    int iterationPicker()
    {
        LineRenderer lineRenderer = GetComponentInParent<LineRenderer>();
        for(int i = 0; i < lineRenderer.positionCount; i++)
        {
            
            float test = Mathf.Abs(transform.position.x - lineRenderer.GetPosition(i).x);
            // Debug.Log(lineRenderer.GetPosition(i).x);
            if(test < 0.2f ){
                
                return i;  
            } 
        }        
        return 0;
    }
}
