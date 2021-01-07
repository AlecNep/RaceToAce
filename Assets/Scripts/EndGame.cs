using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	GameController gc;

	// Use this for initialization
	void Start () {
		GameObject gameCont = GameObject.FindWithTag ("GameController");
		if (gameCont != null) {
			gc = gameCont.GetComponent<GameController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		gc.end ();
	}
			
}
