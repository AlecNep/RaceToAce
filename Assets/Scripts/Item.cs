using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public ItemType itemType;
	public ItemActivate itemObject;

	public enum ItemType{
		Usable,
		PowerUp
	}

	public Item(string name, int id, string desc, ItemType type, ItemActivate obj){

		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
		itemType = type;
		itemObject = obj;

	}

	public Item(){
		
	}
}
