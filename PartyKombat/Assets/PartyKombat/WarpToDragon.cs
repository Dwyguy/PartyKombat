using UnityEngine;
using System.Collections;

public class WarpToDragon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("Player")) {
			for (int i = 0; i<4; i++){
				GameController.control.refKids[i].transform.position = new Vector3(503f+((i*2)-4),139.03f,108f) ;
			}
		}
	}
}
