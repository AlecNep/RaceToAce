using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item> ();

	void Start(){

		items.Add(new Item("Magnet",
							10,
		                   "A regular magnet that can attract metal objects.",
							Item.ItemType.Usable,
							GameObject.FindGameObjectWithTag("Magnet").GetComponent<ItemActivate>()));
		items.Add(new Item("Mop",
							11,
							"An old mop that still seems like it can absorb water.",
							Item.ItemType.Usable,
							GameObject.FindGameObjectWithTag("Mop").GetComponent<ItemActivate>()));
		items.Add (new Item ("Beaker of Chemicals",
							  12,
							 "The label on it reads: \"CAUTION: Chemicals in this beaker have organic growing properties\".",
						      Item.ItemType.Usable,
						      GameObject.FindGameObjectWithTag ("Beaker").GetComponent<ItemActivate> ()));
		items.Add (new Item ("Blowtorch",
							  13,
						     "What kind of school leaves a blowtorch lying around?",
							 Item.ItemType.Usable,
							 GameObject.FindGameObjectWithTag ("BlowTorch").GetComponent<ItemActivate> ()));
		/*items.Add (new Item ("Power Gloves",
							  14,
							 "You can feel immense power in your hands. Your punch is now stronger and can break through stone!",
							 Item.ItemType.Usable,
							 GameObject.FindGameObjectWithTag ("Gloves").GetComponent<ItemActivate> ()));*/
       /* items.Add(new Item("Power Gloves",
                            12,
                            "Strange metal gloves from shop class. Seems to have powered-up pistons on it.",
                            Item.ItemType.Usable,
                            GameObject.FindGameObjectWithTag("Gloves").GetComponent<ItemActivate>()));*/
	}
}
