using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	public Camera mini1;
	public Camera mini2;
	
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		mini1.enabled = false;
		mini2.enabled = true;
		
		
	}
}
