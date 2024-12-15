using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using TMPro;

public class areaDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text displayText;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float totalArea = 0f;
        areaCalc[] areaCalcComponents = GetComponentsInChildren<areaCalc>();
        
        foreach(areaCalc x in areaCalcComponents) // x is random name for components so they can be refered to within the curly braces
        {
            totalArea += x.area;
        }
        Debug.Log(totalArea);
        totalArea = Mathf.Abs(totalArea);
        displayText.text = totalArea.ToString("#0.0000000"); // could not get string.format to work even when i implemented System.Runtime.dll;
    }
}
