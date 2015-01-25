using UnityEngine;
using System.Collections;

public class BridgeRun : MonoBehaviour {

	public GameObject bridgeRot;
	public GameObject bridgeRot2;
	public int frameCounter=0;
	public bool run;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (run) {
			if(frameCounter<90){
				bridgeRot.transform.Rotate(-1,0,0);
				bridgeRot2.transform.Rotate (-1,0,0);
				frameCounter++;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		print ("trigger");
		if(other.tag == "Player" && GameController.control.playerInventory.Find((InventoryObject io) => io.name.Equals ("Gear")).acquired){
			run = true;
		}
	}
}
