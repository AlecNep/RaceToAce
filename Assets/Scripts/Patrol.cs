using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public Transform[] points;
	public int speed;
	public int rotateSpeed;
	public GameObject star;
	public float stunStart, stunEnd;
	public int stunnedRegenRate;
	private int destPoint = 0;
	private bool finishedPatrol;
	private bool stunned;
	private Vector3 targetAngles;

	void Start(){
		finishedPatrol = false;
		stunned = false;
		GotoNextPoint ();
	}

	void GotoNextPoint(){
		if (points.Length == 0) {
			return;
		}
		if (!stunned) {
			if (!finishedPatrol) {
				transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), points [1].position, speed * Time.deltaTime);
			} else {
				transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), points [0].position, speed * Time.deltaTime);
			}


			if (transform.position == points [1].position) {
				transform.Rotate (Vector3.forward * -180);
				//targetAngles = new Vector3(0, 0, -360 * 5);
				//transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, targetAngles, rotateSpeed * Time.deltaTime);
				finishedPatrol = true;
			}

			if (transform.position == points [0].position) {
				transform.Rotate (Vector3.forward * 180);
				finishedPatrol = false;
			}
		}
	}

	void onTriggerStay2D(Collider2D other){
		
		if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("P1Attack")) && gameObject.CompareTag("LoS")) {
			Vector2 direction = (Vector2)(other.gameObject.transform.position - transform.position);
			direction.Normalize ();
			transform.Translate (direction * speed * Time.deltaTime, Space.World);
		}

	}

	public void isStunned(){
		stunned = true;
	}

	void playStar(){
		GameObject stun = (GameObject)Instantiate(star);
		stun.transform.position = transform.position;
	}

	void Update(){
		GotoNextPoint ();
	}

	public IEnumerator monitorStun(){
		if (!stunned) {
			//GameObject.FindGameObjectWithTag ("LoS").SetActive (false);
			stunned = true;
			playStar ();
		while (stunStart < stunEnd) {
			stunStart += Time.deltaTime * stunnedRegenRate;
			yield return null;
		}
		stunStart = 0;
		//GameObject.FindGameObjectWithTag ("LoS").SetActive (true);
		stunned = false;
		//GotoNextPoint ();
		}
	}
}
