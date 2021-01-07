using UnityEngine;
using System.Collections;

public class RobotGun : MonoBehaviour {
	
	public GameObject EnemyLaser;
	public GameObject player;
    float counter;
    public float shotDelay;
    bool canShoot;
	// Use this for initialization
	void Start () {
        canShoot = true;
        
	
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(counter >= shotDelay)
        {
            canShoot = true;
        }
        else
            counter += Time.deltaTime;
    }
	
	void FireLaser(){
		//GameObject player = GameObject.Find("Player");
		
		if(player != null ){
            canShoot = false;
			GameObject laser = Instantiate(EnemyLaser);
			laser.transform.position = transform.position;
			Vector2 direction = player.transform.position - laser.transform.position;
			laser.GetComponent<RobotLaser>().setDirection(direction);
            counter = 0;
		}
	}
	
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.gameObject.GetComponent<Health>().getState().Equals("stunned") && canShoot)
        {
            //InvokeRepeating("FireLaser", 2.0f, 5f);
            FireLaser();
        }
            
    }
	
}
