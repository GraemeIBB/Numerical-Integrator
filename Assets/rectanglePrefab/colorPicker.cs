using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer rRend = GetComponent<SpriteRenderer>();
        rRend.color = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
