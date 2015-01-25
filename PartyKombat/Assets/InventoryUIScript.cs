using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUIScript : MonoBehaviour {

	public Text keyCnt;
	public Text gearCnt;

	// Use this for initialization
	void Start () {
		keyCnt.text = "x x";
		gearCnt.text = "x x";
	}
	
	// Update is called once per frame
	void Update () {
		if(ContainsItem("Key")){
			if(GameController.control.playerInventory.Find((InventoryObject io) => io.name.Equals ("Key")).acquired)
				keyCnt.text = "x 1";
			else
				keyCnt.text = "x 0";
		}
		if(ContainsItem ("Gear")){
			if(GameController.control.playerInventory.Find((InventoryObject io) => io.name.Equals ("Gear")).acquired)
				gearCnt.text = "x 1";
			else
				gearCnt.text = "x 0";
		}
	}

	bool ContainsItem(string name){
		InventoryObject obj = GameController.control.playerInventory.Find ((InventoryObject io) => io.name.Equals (name));
		if (obj == null) {
			return false;
		//} else if (obj.quantity <= 0) {
	//		return false;
		} else
			return true;
	}
}
