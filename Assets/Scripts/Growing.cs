using UnityEngine;
using System.Collections;

public class Growing : MonoBehaviour {


	public GameObject root;
	public GameObject stalk;
	public GameObject floor;
	
	// Use this for initialization
	void Start () {
	
	root.SetActive(true);
	stalk.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == ("Beaker"))
        {
		root.SetActive(false);
		stalk.SetActive(true);
		floor.GetComponent<Collider2D>().enabled = false;
		
        }
    }
}
