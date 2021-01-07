using UnityEngine;
using System.Collections;

public class RobotLaser : MonoBehaviour {

	public float speed;
    float damage;
	Vector2 laserDir;
	bool ready;
    float lifetime;
    float counter;
	
	void Awake(){
		speed = 6.0f;
        damage = 10;
		ready = false;
        counter = 0;
        lifetime = 3;
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	    if(ready){
	    	Vector2 pos = transform.position;
	    	pos += laserDir*speed*Time.deltaTime;
	    	transform.position = pos;
            counter += Time.deltaTime;
            if (counter >= lifetime)
                Destroy(gameObject);
			
		
	
	
	}
	}
	
	public void setDirection(Vector2 direction){
		laserDir = direction.normalized;
		ready=true;
	}
	
	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<Health>().takeDamage(damage);
        }
        else if(col.gameObject.CompareTag("MainFloor"))
            Destroy(gameObject);

    }

}
