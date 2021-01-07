using UnityEngine;
using System.Collections;

public class SlowDownByContact : MonoBehaviour {

	private float speedReduction;
	public Player player;
	public AudioSource vomitWalking;
	public AudioSource waterWalking;
	public float damage;

	private int soundCount;
	private int loSCount;
	private AudioSource sound;

	void Start(){
		
		speedReduction = 0.0f;
		soundCount = 0;
		loSCount = 0;
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Vomit")){
			other.gameObject.GetComponent<Health>().takeDamage(damage);
			speedReduction = 0.1f;
			player.setSpeed (speedReduction);
			sound = vomitWalking;
			firstSound ();
			vomitWalking.loop = true;
			return;
		}

		if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Wet Floor")){
			other.gameObject.GetComponent<Health>().takeDamage(damage);
			speedReduction = 0.3f;
			player.setSpeed (speedReduction);
			sound = waterWalking;
			firstSound ();
			waterWalking.loop = true;
			return;
		}
	
		if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("LoS")){
			//if (loSCount == 0) {
				other.gameObject.GetComponent<Health>().takeDamage(damage);
				speedReduction = 0.05f;
				player.setSpeed (speedReduction);
				//loSCount++;
				return;
			//}

			/*if (loSCount > 0) {
				speedReduction = speedReduction - 0.01f;
				player.setSpeed (speedReduction);
				loSCount++;
			}*/
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") && gameObject.CompareTag ("Vomit")) {
			player.setSpeed (player.getDefaultSpeed());
			vomitWalking.loop = false;
			soundCount = 0;
		} else {
			if (other.gameObject.CompareTag ("Player") && gameObject.CompareTag ("Wet Floor")) {
				player.setSpeed (player.getDefaultSpeed());
				waterWalking.loop = false;
				soundCount = 0;
			} else {
				player.setSpeed (player.getDefaultSpeed());
				loSCount = 0;	
			}
		}
	}

	void firstSound(){
		if (soundCount == 0) {
			sound.Play ();
			soundCount++;
		} else {
			return;
		}
	}

	public void setVomitWalkingLoop(bool newValue){
		vomitWalking.loop = newValue;
	}
}
