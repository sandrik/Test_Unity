using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrack : MonoBehaviour
{
    [SerializeField] private float Speed = 1;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector2 offset = new Vector2(0, Speed * Time.time);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
