using UnityEngine;
using System.Collections;


public class MagneticEffect : MonoBehaviour {

	float speed;
    float damage;
	public bool contact;
	public bool isMagnet;

    void Start()
    {
        damage = 5;
        speed = 5;
    }

	void OnTriggerStay2D(Collider2D other) {

			if (other.gameObject.CompareTag("Magnet") && contact == false) {
                isMagnet = true;
                Vector2 direction = (other.gameObject.transform.position - transform.position);
				direction.Normalize ();
				transform.Translate (direction * speed * Time.deltaTime, Space.World);
				
			}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isMagnet)
            other.gameObject.GetComponent<Health>().takeDamage(damage);
    }

	void OnCollisionStay2D(Collision2D other){
			if (other.gameObject.CompareTag ("Player") && isMagnet) {
				contact = true;
				Destroy (gameObject);
			}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag ("Magnet")) {
			contact = false;
		}
	}

	public bool getIsMagnet(){
		return isMagnet;
	}

	/*void onTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Magnet")) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0.0f, 0.0f);
			contact = false;
		}
	}*/
}

