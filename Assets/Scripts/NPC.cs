using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    AudioSource hit;

	// Use this for initialization
	void Start () {
        hit = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.CompareTag("P1Attack") || col.gameObject.CompareTag("Gloves"))
        {
            hit.Play();
        }
    }
}
