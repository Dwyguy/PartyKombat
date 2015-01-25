using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("Lasso")) {
			for (int i = 0; i<4; i++){
				GameController.control.refKids[i].transform.position  += new Vector3(0,0,-60) ;
			}
		}
		Debug.Log ("HIT");
	}
}
