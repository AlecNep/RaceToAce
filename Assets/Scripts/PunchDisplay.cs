using UnityEngine;
using System.Collections;

public class PunchDisplay : MonoBehaviour {

	public Player player;
	public GameObject gloveDisplay;

	void Start () {

		if (gameObject.CompareTag ("Fist Display")) {
			gameObject.SetActive (true);
		}

		/*if (gameObject.CompareTag ("Glove Display")) {
			gameObject.SetActive (false);
		}*/
	
	}

	void Update () {

		if (player.GetComponent<Attack> ().getGlovesEquipped () && gameObject.CompareTag ("Fist Display")) {
			gameObject.SetActive (false);
			gloveDisplay.SetActive (true);
		}
	}
}
