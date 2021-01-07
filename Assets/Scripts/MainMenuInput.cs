using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            //load ability choice
            SceneManager.LoadScene("ItemSelectionMenu");
        }
        else if (Input.GetButtonDown("Back"))
            SceneManager.LoadScene("Instructions");
        else if (Input.GetButtonDown("XButton"))
        {
            //load the credits, as if anyone cared or wondered who did what haha I mean, there's only 3 of us. we've each basically done a small portion of everything
        }
	}
}
