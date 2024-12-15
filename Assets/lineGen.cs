using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineGen : MonoBehaviour
{
    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int unitLengthOfLineRenderer = 100;
    public int indexesPerUnit = 10;
    public float[] yValues;// simplest way, in my mind, to get y value to children

    void Start()
    {
        yValues = new float[unitLengthOfLineRenderer*indexesPerUnit];
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = (int)unitLengthOfLineRenderer*indexesPerUnit;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
        for (int i = 0; i < unitLengthOfLineRenderer * indexesPerUnit;i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i*(1f/indexesPerUnit), Equation(i,0,indexesPerUnit), 0.0f));
            yValues[i] = lineRenderer.GetPosition(i).y;
        }
    }
    
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        float t = Time.time;
        for (int i = 0; i < unitLengthOfLineRenderer * indexesPerUnit;i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i*(1f/indexesPerUnit), Equation(i,t,indexesPerUnit), 0.0f));
            yValues[i] = lineRenderer.GetPosition(i).y;
        }
        
    }
    float Equation(int x, float t, int indiciesPerUnit) //return value dictates which equation is used
    {
        // return Mathf.Sin((x + t*indexesPerUnit)/indexesPerUnit); /*(working well) */ 
        return Mathf.Sin(Mathf.PI* (x + t*indiciesPerUnit)/indiciesPerUnit); /*(working well) */ 

        return (float)4/(1+(x*x)/indexesPerUnit); /*(working - textbook example on numerical integration)*/
        return (float)x/indiciesPerUnit; /*(working)*/
        return (float)Mathf.Pow(4f,x/(float)indiciesPerUnit); /*(work) */
        
        return Mathf.Sqrt(x/(float)indiciesPerUnit);
        return 1;
        return (x/(float)indiciesPerUnit)*(x/(float)indiciesPerUnit); /* (I think??) */
    }
    
    
    
}

// Mathf.Sin((i + t*indexesPerUnit)/indexesPerUnit) as y of new vector3 on setpos
// for equations, you have to divide x by indexesPerUnit, and multiply t by indexesPerUnit (where applicable)