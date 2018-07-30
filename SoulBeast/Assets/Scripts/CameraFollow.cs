using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float camspeed = 0.1f;
    Camera mycam;

	// Use this for initialization
	void Start () {

        mycam = GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {

        mycam.orthographicSize = (Screen.height / 100f) / 0.7f;

        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, camspeed) + new Vector3(0,0,-10);
        }
		
	}
}
