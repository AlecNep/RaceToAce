using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item> ();
	public bool showInventory;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	void Start () {
		for(int i = 0; i < (slotsX * slotsY); i++){
			slots.Add (new Item ());
			inventory.Add (new Item ());
		}
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
	}

	void Update(){
		
		if (Input.GetButtonDown ("Inventory")) {
			showInventory = !showInventory;
		}
	}

	void OnGUI(){
		
		tooltip = "";
		GUI.skin = skin;
		//if (showInventory) {
			DrawInventory ();
		//}

		if (showTooltip) {
			GUI.Box (new Rect (Event.current.mousePosition.x + 15, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
		}
			
	}

	void DrawInventory(){

		int i = 0;
		for (int y = 0; y < slotsY; y++){
			
			for(int x = 0; x < slotsX; x++){
				Rect slotRect = new Rect (7 + x*50, 80 + (y*20), 40, 40);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots [i] = inventory [i];
				if(slots[i].itemName != null){
					GUI.DrawTexture (slotRect, slots [i].itemIcon);
					if(slotRect.Contains(Event.current.mousePosition)){
						tooltip = CreateTooltip (slots [i]);
						//showTooltip = true;	
					}
				}

				if (tooltip == "") {
					showTooltip = false;
				}

				i++;
			}
			
		}

	}

	string CreateTooltip(Item item){
		tooltip = "<color=#ffffff>" + item.itemName + "</color>\n\n" + item.itemDesc;
		return tooltip;
	}

	void RemoveItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i].itemID == id) {
				inventory [i] = new Item ();
				break;
			}
		}
	}

	public void AddItem(int id){

		for(int i = 0; i < inventory.Count; i++){

			if (inventory [i].itemName == null) {
				for(int j = 0; j < database.items.Count; j++){
					if(database.items[j].itemID == id){
						inventory [i] = database.items [j];	
					}
				}
				break;
			}
		}

	}

	public bool InventoryContains(int id){
		foreach (Item Item in inventory) {
			if (Item.itemID == id)
				return true;	
		}

		return false;
	}

	public int getInventoryCount(){
		return inventory.Count;
	}

	public string getItemNameFromIndex(int i){
		return inventory [i].itemName;
	}

	public int getItemIDFromIndex(int i){
		return inventory [i].itemID;
	}

	public ItemActivate getItemObjectFromIndex(int i){
		return inventory [i].itemObject;
	}
}
