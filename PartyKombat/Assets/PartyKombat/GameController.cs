using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController control;

	public Rigidbody lassoShot;
	public float lassoSpeed = 100f;
	public bool lassoFlag;

	public short currentKid;
	public GameObject [] refKids;
	public bool crouching;

	public List<InventoryObject> playerInventory;

	void Awake(){
		playerInventory = new List<InventoryObject> ();
		//playerInventory.Add(new InventoryObject(0, "Key");
		crouching = false;
		refKids = new GameObject[4];
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
			currentKid = 1;
		} else {
			Destroy(gameObject);
		
		}
	}


	void setCurrentKid(short ck){
		currentKid = ck;
	}

	public void setRefKid(GameObject rk, int ck){
		refKids[ck-1] = rk;
	}

	public void shootLasso(Vector3 pos, Quaternion direction){
		if (!lassoFlag) {
				Rigidbody lassoClone = (Rigidbody) Instantiate(lassoShot,pos+new Vector3(0,1,0), direction);

			lassoClone.velocity = lassoClone.transform.forward * lassoSpeed;
		
				lassoFlag = true;
		}
	}
}
