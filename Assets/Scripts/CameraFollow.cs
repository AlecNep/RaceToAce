using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	
	public Transform player;
	public Camera mini1;
	public float camSpeed = 0.1f;
    Vector3 offset;
	
	
	// Use this for initialization
	void Start () {
		mini1.enabled = true;
        offset = transform.position - player.position;
	
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	
		transform.position = Vector3.Lerp(transform.position, player.position, camSpeed) + offset;
		
		
	
	
//	}
	
	}
}
