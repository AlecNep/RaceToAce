using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    

    public float speed;
    public float rotationSpeed;
	static int powerUpType;
    private float step;
	private int puddleTotal;
	private int puddleCount;
	private bool robotAlive;
	private float defaultSpeed;
	
	
	public int hallPassTotal;
	public int hallPassCount;
    
    
    AudioSource hit;

	// Use this for initialization
	void Start () {
        hit = GetComponent<AudioSource>();
		puddleTotal = 15;
		puddleCount = 0;
		if (powerUpType == 1) {
			speed = 0.75f;
			defaultSpeed = speed;
		}
		else{
			speed = 0.5f;
			defaultSpeed = speed;
		}
		robotAlive = true;
		print("PowerUp Ability: " + powerUpType);
		print("Player speed: " + speed);
		
		
		
		hallPassTotal = 3;
		hallPassCount = 0;
		
	}

	
	
	// Update is called once per frame
	void LateUpdate () {
        float movementX = Input.GetAxis("LStickX");
        float movementY = Input.GetAxis("LStickY");

        if (!Mathf.Approximately(movementX, 0.0f) || !Mathf.Approximately(movementY, 0.0f))
        {
            Vector3 movement = new Vector3(movementX, movementY, 0f);
            movement = Vector3.ClampMagnitude(movement, 1f);
            step = rotationSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.up, movement, step, 0f);
            Quaternion dir = Quaternion.LookRotation(Vector3.forward, newDir);
            transform.rotation = dir;
            transform.position += movement * speed;
        }
        
    }

	public static void setPowerUpType(int p)
	{
		powerUpType = p;
	}

	public static int getPowerUpType()
	{
		return powerUpType;
	}
    

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("P1Attack") || col.gameObject.CompareTag("MainFloor"))
        {
            return;
        }
        else 
        {
            /*if (col.gameObject.CompareTag("NPCAttack"))
                takeDamage(5);
            else if (col.gameObject.CompareTag("Nail"))
                takeDamage(10);*/
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("P1Attack"))
        {
            return;
        }
    }
	
	public void setSpeed(float newSpeed){
		speed = newSpeed;	
	}

	public float getSpeed(){
		return speed;
	}

	public void addPuddleCount(int addValue){
		puddleCount += addValue;
	}

	public void setPuddleCount(int newCount){
		puddleCount = newCount;
	}

	public int getPuddleCount(){
		return puddleCount;
	}

	public int getPuddleTotal(){
		return puddleTotal;
	}

	public void setRobotAlive(bool newValue){
		robotAlive = newValue;
	}

	public bool getRobotAlive(){
		return robotAlive;
	}

	public float getDefaultSpeed(){
		return defaultSpeed;
	}
	
	
		public void addHallPassCount(int add){
		hallPassCount++;
	}
	
	public void setHallPassCount(int count){
		hallPassCount = count;
	}
	
	public int getHallPassCount(){
		return hallPassCount;
	}
	
	public int getHallPassTotal(){
		return hallPassTotal;
	}
}
