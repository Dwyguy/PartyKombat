using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUIScript : MonoBehaviour {

	public Text keyCnt;
	public Text gearCnt;

	// Use this for initialization
	void Start () {
		keyCnt.text = "";
		gearCnt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		keyCnt.text = GameController.control.playerInventory.Find((InventoryObject io) => io.name.Equals ("Key")).getQty().ToString();
		gearCnt.text = GameController.control.playerInventory.Find((InventoryObject io) => io.name.Equals ("Gear")).getQty().ToString();
	}
}
