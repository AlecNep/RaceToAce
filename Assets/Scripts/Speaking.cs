using UnityEngine;
using System.Collections;

public class Speaking : MonoBehaviour {

	public GameObject speakingIcon;

	public string npcName;
	public GameObject vomit;
	private string janitorDialogue;
	private string strangerDialogue;
	private string bioKidDialogue;
	private bool canTalk;
	private bool showDialogue;

	void Start(){
		speakingIcon.SetActive (false);
		canTalk = false;
		showDialogue = false;
		janitorDialogue = "\n<b>Janitor</b>" +
						  "\nThere was a big leak last night and now there is water all over this floor. " +
						  "\nI would clean it, but I'm way too hungover from the party last night." +
						  "\nIf you do it for me, I might find the strength to move." +
						  "\nI think there is a mop in the maintenance room.";
		strangerDialogue = "\n<b>Stranger</b>" +
						   "\nUgh...I don't feel well. " +
						   "\nI knew I shouldn't have went out partying with the janitor last night.";
		bioKidDialogue = "\n<b>Science Kid</b>" +
						 "\n We really messed up this time! " +
						 "\nThe robot we made is running rampant in one of the classrooms!" +
						 "\n Please go destroy it somehow before the principal finds out!" +
						 "\n If you get it done, come back here and there might be something useful!";
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") && gameObject.CompareTag ("Speakable") || gameObject.CompareTag ("Bio Kid")) {
			speakingIcon.SetActive (true);
			canTalk = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") && gameObject.CompareTag ("Speakable") || gameObject.CompareTag ("Bio Kid")) {
			speakingIcon.SetActive (false);
			showDialogue = false;
			canTalk = false;
		} 
	}
		
	void Update(){
		bool swapCountButton = Input.GetButtonDown ("AButton");

		if (swapCountButton && canTalk) {
			if (!showDialogue) {
				showDialogue = true;
			} else {
				showDialogue = false;
			}
		}
			
	}

	void OnGUI(){
		if (showDialogue) {
			if (npcName == "Janitor") {
				GUI.Box (new Rect (500, 50, 500, 100), janitorDialogue);
			}

			if (npcName == "Stranger") {
				//vomit.GetComponent<AudioSource> ().loop = false;
				GUI.Box (new Rect (500, 50, 500, 100), strangerDialogue);
			}

			if (npcName == "Bio Kid") {
				GUI.Box (new Rect (500, 50, 500, 100), bioKidDialogue);
			}
		}
	}

	public void setShowDialogue(bool newBool){
		showDialogue = newBool;
	}
}
