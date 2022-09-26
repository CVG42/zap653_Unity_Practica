using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-2 * Time.deltaTime, 0);
        if(transform.position.x < -2.89)
        {
            transform.position = new Vector3(5.85f, transform.position.y);
        }
    }
}
