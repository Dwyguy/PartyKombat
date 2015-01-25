using UnityEngine;
using System.Collections;

public class InventoryObject {
	public int quantity = 0;
	public string name = "x";

	public InventoryObject(){
		// create object
	}

	public InventoryObject(int qty, string name){
		this.quantity = qty;
		this.name = name;
	}

	public void editQty(int i){
		quantity += i;
	}

	public int getQty(){
		return quantity;
	}


}
