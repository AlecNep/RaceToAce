using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public GameObject leftFist;
    public GameObject rightFist;
	public GameObject leftGlove;
	public GameObject rightGlove;
    public GameObject projectile;
    public ItemActivate[] items;
	public Inventory inventory;

	public Player player;
    public float offsetDist;
    public float projOffsetDist;
    public float punchSpeed;
    public float projSpeed;
    public float projTime;
    public float punchTime;
    bool thrownRight;
    bool thrownLeft;
    bool thrownProj;

	private int numOfItems;
	private int itemScroll;
	private bool[] haveItem;
	private bool useNextItem;
	private int swapCount;
	private bool glovesEquipped;
    

	// Use this for initialization
	void Start () {
        thrownLeft = false;
        thrownRight = false;
        thrownProj = false;
		haveItem = new bool[5];
		numOfItems = 0;
		itemScroll = 0;
		useNextItem = false;
		swapCount = 0;
		glovesEquipped = false;
	}
	
	// Update is called once per frame
	void Update () {
        float attackX = Input.GetAxis("RStickX");
        float attackY = Input.GetAxis("RStickY");
        bool projectile = Input.GetButton("RBumper");
        bool equip = Input.GetButton("LBumper");
		bool swapCountButton = Input.GetButtonDown ("AButton");

		if (projectile) {
			if (!Mathf.Approximately (attackX, 0f) || !Mathf.Approximately (attackY, 0f)) {
				StartCoroutine (throwProjectile (new Vector3 (attackX, attackY, 0f)));
			}
		} else if (equip && inventory.getItemNameFromIndex (0) != null)
        	{

			if (swapCountButton) {
				swapCount++;
			}

			//items [0].setItemActive (true);

			if (inventory.getItemNameFromIndex (0) != null && swapCount == 0) {
				inventory.getItemObjectFromIndex (0).setItemActive (true);
				//Display description of item under inventory
				if (inventory.getItemNameFromIndex(1) != null) {
					inventory.getItemObjectFromIndex (1).setItemActive (false);
				}
			}

			if (inventory.getItemNameFromIndex (0) != null && inventory.getItemNameFromIndex (1) != null && swapCount == 1) {
					inventory.getItemObjectFromIndex (1).setItemActive (true);
					//Display description of item under inventory
					inventory.getItemObjectFromIndex (0).setItemActive (false);
			}
			if (inventory.getItemNameFromIndex (0) != null && inventory.getItemNameFromIndex (2) != null && swapCount == 2) {
				inventory.getItemObjectFromIndex (2).setItemActive (true);
				//Display description of item under inventory
				inventory.getItemObjectFromIndex (1).setItemActive (false);
			}
			if (inventory.getItemNameFromIndex (0) != null && inventory.getItemNameFromIndex (3) != null && swapCount == 3) {
				inventory.getItemObjectFromIndex (3).setItemActive (true);
				//Display description of item under inventory
				inventory.getItemObjectFromIndex (2).setItemActive (false);
			}

        }

        else
        {
			swapCount = 0;
			for (int i = 0; i < items.Length; i++) {
				items [i].setItemActive (false);
			}
			if (!Mathf.Approximately(attackX, 0f) || !Mathf.Approximately(attackY, 0f))
            {
                StartCoroutine(punch(new Vector3(attackX, attackY, 0f)));
            }
        }
        
	}

    IEnumerator punch(Vector3 punchDir)
	{
		//print("punching");

		punchDir.Normalize ();
		float angle = Vector3.Angle (transform.up, punchDir);// *sign;
		Vector3 cross = Vector3.Cross (punchDir, transform.up);
		if (cross.z < 0) {
			angle = -angle;
		}

		Quaternion direction = Quaternion.LookRotation (Vector3.forward, punchDir);
        

		if (!glovesEquipped) {
			if ((angle >= 0 && angle < 180) && thrownRight == false) {
			
				//throw right fist
				thrownRight = true;
				//rDir = punchDir;
				float timerR = 0f;
				Vector3 attackOffsetR = transform.position + (punchDir * offsetDist);
				GameObject right = (GameObject)Instantiate (rightFist, attackOffsetR, direction);
				while (timerR <= punchTime) {
					attackOffsetR = transform.position + (punchDir * offsetDist);
					right.transform.position = (attackOffsetR) + (float)(Mathf.Sin (timerR / punchTime * Mathf.PI) + 1f) * punchDir;
					yield return null;
					timerR += Time.deltaTime * punchSpeed;
				}

				right.transform.position = attackOffsetR;
				Destroy (right);
				thrownRight = false;
            
            
			} else if ((angle < 0 || angle == 180) && thrownLeft == false) {
				//throw left fist
				thrownLeft = true;
				float timerL = 0f;
				Vector3 attackOffsetL = transform.position + (punchDir * offsetDist);
				GameObject left = (GameObject)Instantiate (leftFist, attackOffsetL, direction);
				while (timerL <= punchTime) {
					attackOffsetL = transform.position + (punchDir * offsetDist);
					left.transform.position = attackOffsetL + (float)(Mathf.Sin (timerL / punchTime * Mathf.PI) + 1f) * punchDir;
					yield return null;
					timerL += Time.deltaTime * punchSpeed;
				}

				left.transform.position = attackOffsetL;
				Destroy (left);
				thrownLeft = false;

			}
		} 
		else {
			if ((angle >= 0 && angle < 180) && thrownRight == false) {

				//throw right fist
				thrownRight = true;
				//rDir = punchDir;
				float timerR = 0f;
				Vector3 attackOffsetR = transform.position + (punchDir * offsetDist);
				GameObject right = (GameObject)Instantiate (rightGlove, attackOffsetR, direction);
				while (timerR <= punchTime) {
					attackOffsetR = transform.position + (punchDir * offsetDist);
					right.transform.position = (attackOffsetR) + (float)(Mathf.Sin (timerR / punchTime * Mathf.PI) + 1f) * punchDir;
					yield return null;
					timerR += Time.deltaTime * punchSpeed;
				}

				right.transform.position = attackOffsetR;
				Destroy (right);
				thrownRight = false;


			} else if ((angle < 0 || angle == 180) && thrownLeft == false) {
				//throw left fist
				thrownLeft = true;
				float timerL = 0f;
				Vector3 attackOffsetL = transform.position + (punchDir * offsetDist);
				GameObject left = (GameObject)Instantiate (leftGlove, attackOffsetL, direction);
				while (timerL <= punchTime) {
					attackOffsetL = transform.position + (punchDir * offsetDist);
					left.transform.position = attackOffsetL + (float)(Mathf.Sin (timerL / punchTime * Mathf.PI) + 1f) * punchDir;
					yield return null;
					timerL += Time.deltaTime * punchSpeed;
				}

				left.transform.position = attackOffsetL;
				Destroy (left);
				thrownLeft = false;

			}
		}
    }

    IEnumerator throwProjectile(Vector3 throwDir)
    {
        if(thrownProj == false)
        {
            thrownProj = true;
            float pTimer = 0f;
            throwDir.Normalize();
            float angle = Vector3.Angle(transform.up, throwDir);// *sign;
            Vector3 cross = Vector3.Cross(throwDir, transform.up);
            if (cross.z < 0)
            {
                angle = -angle;
            }
            Vector3 attackOffset = transform.position + (throwDir * projOffsetDist);
            Quaternion direction = Quaternion.LookRotation(Vector3.forward, throwDir);
            GameObject proj = (GameObject)Instantiate(projectile, attackOffset, direction);
            proj.gameObject.GetComponent<Rigidbody2D>().AddForce(throwDir * projSpeed, ForceMode2D.Impulse);
            while(pTimer <= projTime)
            {
                yield return null;
                pTimer += Time.deltaTime;
            }
            
            Destroy(proj);
            thrownProj = false;
        }
        
    }

	public void setHaveItem(int index, bool value){
		haveItem [index] = value;
		numOfItems++;
	}

	public bool getHaveItem(int index){
		return haveItem [index];
	}

	public bool[] getHaveItemArray(){
		return haveItem;
	}

	/*public bool checkIfGloves(int i){
		if (inventory.getItemNameFromIndex (i) == "Power Gloves") {
			glovesEquipped = true;
			return true;
		} 
		else {
			return false;
		}
	}*/

	public void setGlovesEquipped(bool newValue){
		glovesEquipped = newValue;
	}

	public bool getGlovesEquipped(){
		return glovesEquipped;
	}
}
