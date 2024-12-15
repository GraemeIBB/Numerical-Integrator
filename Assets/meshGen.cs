using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshGen : MonoBehaviour
{
    //primary use of this script is to instantiate rects with vertical centres located on line graph, with height y at x
    //will pass through dimentions of rects, and add area of rects, giving area underneath line.
    //will pass area to text that is updated every fixedupdate (not update, for performance reasons), text to canvas.
    
    public int numOfRect = 10;
    public GameObject rectanglePF;
    public Transform parent; //this is required for the instantiate constructor, just kidding ig idk what the fuck is going on

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //divide line into numOfRect segments
        //instantiate numOfRect rectangles with width of lineRenderer.positionCount / numOfRect
        //after instantiating, add lineRenderer.positionCount / numOfRect to x transform ( or some ratio of, not sure yet)
        //every update, edit y scale to follow point at y such that midpoint of rect intersects specified y point at any given moment.
        lineGen lineGenerator = GetComponent<lineGen>(); // is needed to find specifics of line generation (indexes per unit, length in units)
        
        for(int i = 0; i < numOfRect; i++)
        {
            GameObject rectangle = (GameObject) Instantiate(rectanglePF, new Vector3((lineGenerator.unitLengthOfLineRenderer / (float)numOfRect) / 2f * (2*i+1), 0f, 0f), Quaternion.identity, parent);
            //color picker handled on per instance basis
            rectangle.transform.localScale = new Vector3(lineGenerator.unitLengthOfLineRenderer/(float)numOfRect, 1, 0);
            
            Debug.Log("Color for rectangle " + (i+1) + " chosen");
            
        }
    }

    // Update is called once per frame
    
}


//future plans (in order of importance):
// - handle non integer lengths of line
// - handle 1/3 better
// - use bounds on functions rather than starting at 0
// - make 3d render
// - handle radians
