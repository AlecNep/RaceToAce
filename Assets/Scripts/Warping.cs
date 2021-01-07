using UnityEngine;
using System.Collections;

public class Warping : MonoBehaviour {
	
	
	// Use this for initialization
	public Transform warp;
	//private Vector3 startPos;

	GameObject itemGO;
	

	void Start () {
	
		//cam = GetComponent<Camera>();
		itemGO = GameObject.Find ("magnet (held)");
		//startPos = new Vector3 (-2.6f, 27.1f, 0f);
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		ItemActivate item = itemGO.GetComponent<ItemActivate> ();
		if (col.tag == "Player") {
			foreach (bool value in item.getHaveItemArray()) {
				if (value) {
					item.setItemActive (false);
					col.gameObject.transform.position = warp.position;
					Camera.main.transform.position = warp.position;
					item.setItemActive (true);
					return;
				} else {
					col.gameObject.transform.position = warp.position;
					Camera.main.transform.position = warp.position;
					return;
				}
			
			}
		}
		
		
	}
	
	

	
	
}
