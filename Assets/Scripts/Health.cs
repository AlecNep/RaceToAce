using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Health : MonoBehaviour {

    private float maxStamina = 100;
	private float monitorStamina = 1;
    private float curStamina;
    public float regenRate;
    public float regenDelay;
    float timeSinceHit;
    public enum State { healed, delay, healing, stunned};
    State curState;
    public float stunnedRegenRate;
    public Slider staminaBar;
	public bool godMode;
    Player movement;
	public Player player;
	
	
	//HallPass
	public GameObject hallPass;
	public int lives;
	public Text LivesUI;

	//Stun anim
	public GameObject star;
	
    // Use this for initialization
    void Start () {
        movement = GetComponent<Player>();
		if (Player.getPowerUpType() == 2)
			maxStamina = 150;
		else maxStamina = 100;
		print("Max stamina: " + maxStamina);
        curStamina = maxStamina;
		staminaBar.maxValue = maxStamina;
		updateStaminaBar ();
        curState = State.healed;
		hallPassUI();
		if (Player.getPowerUpType () == 3) {
			lives = 1;
		} else {
			lives = 0;
		}
		//godMode = false;
    }
	
	public bool godModeState(){
		
		if(lives > 0){
		godMode =false;
		}
		else 
			godMode= true;
		return godMode;
	}
	
	// Update is called once per frame
	void Update () {
		hallPassUI();
	    if(curState == State.delay)
        {
            if (timeSinceHit >= regenDelay)
                curState = State.healing;
            else
                timeSinceHit += Time.deltaTime * regenRate;
        }
        else if(curState == State.healing)
        {
            if(curStamina >= maxStamina)
            {
                curStamina = maxStamina;
                updateStaminaBar();
                curState = State.healed;
            }
            else
            {
                curStamina += Time.deltaTime * regenRate;
                updateStaminaBar();
            }
                
        }
        
	}

    void updateStaminaBar()
    {
        staminaBar.value = curStamina;
    }

    public string getState()
    {
        return curState.ToString();
    }

    public void takeDamage(float amount)
    
	{/*if(godMode){*/
        if(curState != State.stunned) //make sure player can't take damage if already stunned
        {
            curStamina -= amount;
            updateStaminaBar();
            if (curStamina <= 0)
            {
                StartCoroutine(stun());
				playStar();
            }
            else
            {
                timeSinceHit = 0;
                curState = State.delay;
           // }
        }
	}  

    }

	public void setToFull(){
		curStamina = maxStamina;
	}

    IEnumerator stun()
    {
        curState = State.stunned;
        movement.enabled = false;
        while(curStamina < maxStamina)
        {
            //spinning stars
            curStamina += Time.deltaTime * stunnedRegenRate;
            updateStaminaBar();
            yield return null;
        }
        movement.enabled = true;
        curState = State.healed;
        if (curStamina > maxStamina)
        {
            curStamina = maxStamina;
            updateStaminaBar();
        }
    }
	
	void playStar(){
		GameObject stun = (GameObject)Instantiate(star);
		stun.transform.position = transform.position;
	}
	
	/*void OnTriggerEnter2D(Collider2D col){
		if(col.tag == ("HallPassPiece") && player.getHallPassCount() == 3){
			
			lives= lives +1;
		hallPassUI();
			
			Destroy(col.gameObject);
		}	
	}*/
	
	public void hallPassUI(){
		LivesUI.text = lives.ToString();
	}
	
	public void setLives(int newValue){
		lives = newValue;
	}
	
	public void hit(){
		
		lives--;
	}
	
	public int getLivesCount(){
		return lives;
	}
		
}
