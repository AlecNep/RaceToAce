using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlsMenuInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("BButton"))
            SceneManager.LoadScene("MainMenu");
	}
}
