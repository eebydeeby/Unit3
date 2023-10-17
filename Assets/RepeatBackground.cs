// Script for scrolling background to the left
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	private Vector3 startPos;
	private float repeatWidth;
	
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
		repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

	// Moves background left and then repeats after a certain point
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
		{
			transform.position = startPos;
		}
    }
}
