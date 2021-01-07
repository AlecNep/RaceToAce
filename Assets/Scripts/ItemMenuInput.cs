using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ItemMenuInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("XButton"))
        {
            //load scene with coffee
            Player.setPowerUpType(1);
            SceneManager.LoadScene("MainGame");
        }
        else if (Input.GetButtonDown("AButton"))
        {
            //load scene with power bar
            Fist.setPunchPower(130);
            Player.setPowerUpType(2);
            SceneManager.LoadScene("MainGame");
        }
        else if (Input.GetButtonDown("BButton"))
        {
            //load scene with hall pass
            Player.setPowerUpType(3);
            SceneManager.LoadScene("MainGame");
        }

	}
}
