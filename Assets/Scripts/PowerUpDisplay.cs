using UnityEngine;
using System.Collections;

public class PowerUpDisplay : MonoBehaviour {

	public GameObject otherPowerUp;
	public GameObject otherPowerUp2;

	void Start () {
		
		if (gameObject.CompareTag ("Coffee Display") && Player.getPowerUpType () == 1) {
			gameObject.SetActive (true);
			otherPowerUp.SetActive (false);
			otherPowerUp2.SetActive (false);
		}

		if (gameObject.CompareTag ("Bar Display") && Player.getPowerUpType () == 2) {
			gameObject.SetActive (true);
			otherPowerUp.SetActive (false);
			otherPowerUp2.SetActive (false);
		}

		if (gameObject.CompareTag ("No PowerUp Display") && Player.getPowerUpType () == 3) {
			gameObject.SetActive (true);
			otherPowerUp.SetActive (false);
			otherPowerUp2.SetActive (false);
		}
	
	}

}
