using UnityEngine;
using System.Collections;

public class InventoryObject {
	public int quantity = 0;
	public string name = "x";
	public bool acquired = false;

	public InventoryObject(){
		// create blank object
	}

	public InventoryObject(int qty, string name, bool acquired){
		this.quantity = qty;
		this.name = name;
		this.acquired = acquired;
	}

	public void editQty(int i){
		quantity += i;
	}

	public int getQty(){
		return quantity;
	}

	public void addObject(){
		GameController.control.playerInventory.Add(this);
	}


}
