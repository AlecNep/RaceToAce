using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text timer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = "Time: " + Time.realtimeSinceStartup;
	}

	public void end(){
		Debug.Log (Time.realtimeSinceStartup);
		WinScreen.setFinishTime(Mathf.Round(Time.realtimeSinceStartup*100f)/100f); 
		SceneManager.LoadScene("WinScreen");
	}
	

}
