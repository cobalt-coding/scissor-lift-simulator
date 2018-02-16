using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerFP : MonoBehaviour {

    public GameObject Robot;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Robot.transform.position + new Vector3(0, 1, 0);
	}
}
