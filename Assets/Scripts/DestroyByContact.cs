using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour {

	public ItemActivate item;
	public Transform warp;
	public Player player;
	public Inventory inventory;
	public AudioClip crumblingSound;
	public GameController gameController;
	
	//
	public int lives;
	
	//Fire Anim
	public GameObject Fire;
	public GameObject Explosion;

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") && gameObject.CompareTag("Item")){
			Destroy(gameObject);
			//item.setItemActive (true);

			if(item.CompareTag("Magnet")){
				player.GetComponent<Attack> ().setHaveItem (0, true);
				inventory.AddItem(10);
			}

			if(item.CompareTag("Mop")){
				player.GetComponent<Attack> ().setHaveItem (1, true);
				inventory.AddItem(11);
			}
				
			if(item.CompareTag("BlowTorch")){
				player.GetComponent<Attack> ().setHaveItem (3, true);
				inventory.AddItem(13);
			}

			if(item.CompareTag("Gloves")){
				player.GetComponent<Attack> ().setGlovesEquipped (true);
				/*player.GetComponent<Attack> ().setHaveItem (4, true);
				inventory.AddItem(14);*/
			} 
		}

		if(other.CompareTag("Player") && gameObject.CompareTag("Beaker World")){
				Destroy(gameObject);
				player.GetComponent<Attack> ().setHaveItem (2, true);
				inventory.AddItem(12);
		}

		if (other.CompareTag ("Mop") && gameObject.CompareTag ("Wet Floor")) {
			player.addPuddleCount (1);
			Destroy (gameObject);
			//play mop up sound
		}
		//Change to blowtorch!
		if (other.CompareTag("BlowTorch") && gameObject.CompareTag("Chair")){
            print("trying to burn stuff");
			playFire();
			Destroy(gameObject);
		}

		if (other.CompareTag ("Magnet") && gameObject.CompareTag ("Robot")) {
            print("trying to blow up stuff");
            playExplosion();
			Destroy(gameObject);
			player.setRobotAlive (false);
		}

		if (other.CompareTag ("Gloves") && gameObject.CompareTag ("Cement")) {
			AudioSource.PlayClipAtPoint (crumblingSound, new Vector3(5, 26, 0));
			Destroy(gameObject);
		}
		/**************************************/
		if(other.CompareTag("Player") && gameObject.CompareTag("HallPassPiece")){

			Destroy (gameObject);
			player.GetComponent<Player>().addHallPassCount(1);

			if( player.getHallPassCount() == player.getHallPassTotal()){
				player.GetComponent<Health>().setLives(1);
				
			}
		}
		/**************************************/

		if (other.CompareTag ("Player") && gameObject.CompareTag ("Trophy")) {
			gameController.end ();
		}
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.collider.CompareTag("Player")  && gameObject.CompareTag("Enemy")){
			//godMode
			bool ready = other.gameObject.GetComponent<Health>().godModeState();
			int lives = other.collider.GetComponent<Health>().getLivesCount();	
			if(lives == 0){
			//if(ready){
			other.gameObject.transform.position = warp.position;
			//other.gameObject.GetComponent<Health> ().setToFull ();
			Camera.main.transform.position = warp.position;
			}
			else{
				other.collider.GetComponent<Health>().hit();
			}
		}

		if ((other.collider.CompareTag ("P1Attack")||other.collider.CompareTag ("Gloves"))  && gameObject.CompareTag ("Enemy")) {
			
			bool ready = player.gameObject.GetComponent<Health>().godModeState();

			if(ready){
				player.transform.position = warp.position;
				//other.gameObject.GetComponent<Health> ().setToFull ();
				Camera.main.transform.position = warp.position;
			}
		}

		if (other.collider.CompareTag ("Player") && gameObject.CompareTag ("Ball")) {
			player.GetComponent<Health> ().takeDamage (50);
		}
			
		if (other.collider.CompareTag ("Pencil") && gameObject.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
			gameObject.GetComponent<Patrol> ().StartCoroutine(gameObject.GetComponent<Patrol> ().monitorStun ());
		}

        if (other.collider.CompareTag("BlowTorch") && gameObject.CompareTag("Chair"))
        {
            print("trying to burn stuff");
            playFire();
            Destroy(gameObject);
        }

        if (other.collider.CompareTag("Magnet") && gameObject.CompareTag("Robot"))
        {
            print("trying to blow up stuff");
            playExplosion();
            Destroy(gameObject);
            player.setRobotAlive(false);
        }

        if (other.collider.CompareTag("Gloves") && gameObject.CompareTag("Cement"))
        {
            print("Trying to smash stuff");
            AudioSource.PlayClipAtPoint(crumblingSound, new Vector3(5, 26, 0));
            Destroy(gameObject);
        }
    }
	
	void playFire(){
		GameObject flame = (GameObject)Instantiate(Fire);
		flame.transform.position = transform.position;
	}
	
	void playExplosion(){
		GameObject boom = (GameObject)Instantiate(Explosion);
		boom.transform.position = transform.position;
	}
}
