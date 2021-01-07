using UnityEngine;
using System.Collections;

public class DestroyByObjective : MonoBehaviour {

	public Player player;
	public GameObject beakerWorldItem;

	void Start(){
		//beakerWorldItem.SetActive (false);
	}

	void Update () {

		if (player.getPuddleCount() == player.getPuddleTotal() && gameObject.CompareTag("Speakable")) {
			player.setPuddleCount (0);
			Destroy (gameObject);
		}
			
		if (!player.getRobotAlive () && gameObject.CompareTag("Bio Kid")) {
			beakerWorldItem.SetActive (true);
			Destroy (gameObject);
		}
	
	}
}
