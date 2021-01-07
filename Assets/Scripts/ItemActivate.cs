using UnityEngine;
using System.Collections;

public class ItemActivate : MonoBehaviour {

	public Player player;
	public bool itemActive;
	public GUISkin skin;
	private bool[] haveItem; //0 = magnet, 1 = mop
	private int numOfItems;
	private bool showTooltip;
	private string tooltip;
    AudioSource buzz;

	void Awake(){
        buzz = GetComponent<AudioSource>();
        itemActive = false;
		numOfItems = 0;
		haveItem = new bool[5];
		showTooltip = false;
	}

	void Update(){
		if(gameObject.CompareTag("Magnet")){
			gameObject.SetActive (itemActive);
			showTooltip = true;
        	if (itemActive && !buzz.isPlaying)
       	 	{
           	 	buzz.Play();
       	 	}
		}

		if(gameObject.CompareTag("Mop")){
			gameObject.SetActive (itemActive);
			showTooltip = true;
		}

		if(gameObject.CompareTag("Beaker")){
			gameObject.SetActive (itemActive);
			showTooltip = true;
		}

		if(gameObject.CompareTag("BlowTorch")){
			gameObject.SetActive (itemActive);
			showTooltip = true;
		}

        if (gameObject.CompareTag("Gloves"))
        {
            /*gameObject.SetActive(itemActive);
			player.GetComponent<Attack> ().setGlovesEquipped (true);*/
        }

        //else gameObject.GetComponent<Fist>().powered(true);


    }

	void OnGUI(){
		tooltip = "";
		GUI.skin = skin;
		if(gameObject.CompareTag("Magnet")){
			tooltip = "<color=#ffffff>" + "Magnet" + "</color>\n" + "A regular magnet that can attract metal objects.";	
		}
		if(gameObject.CompareTag("Mop")){
			tooltip = "<color=#ffffff>" + "Mop" + "</color>\n" + "An old mop that still seems like it can absorb water.";
		}
		if(gameObject.CompareTag("Beaker")){
			tooltip = "<color=#ffffff>" + "Beaker of Chemicals" + "</color>\n" + "The label on it reads: \"CAUTION: Chemicals in this beaker have organic growing properties\".";
		}
		if(gameObject.CompareTag("BlowTorch")){
			tooltip = "<color=#ffffff>" + "Blowtorch" + "</color>\n" + "What kind of school leaves a blowtorch lying around?";
		}

		if (showTooltip) {
			GUI.Box (new Rect (14, 130, 200, 150), tooltip, skin.GetStyle("Tooltip"));
		}
	}
		
	public void setItemActive(bool active){
		if (gameObject.CompareTag ("Gloves")) {
			return;
		} else {
			gameObject.SetActive (active);
		}
		//Debug.Log("Item is: " + active);
		itemActive = active;
	}

	public void setHaveItem(int index, bool have){
		haveItem[index] = have;
	}

	public void setNumOfItems(int addItem){
		numOfItems += addItem;
	} 

	public bool getItemActive(){
		return itemActive;
	}

	public bool getHaveItem(int index){
		return haveItem[index];
	}

	public bool[] getHaveItemArray(){
		return haveItem;
	}

	public int getNumOfItems(){
		return numOfItems;
	}
}
