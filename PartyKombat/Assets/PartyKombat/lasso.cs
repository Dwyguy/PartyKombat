using UnityEngine;
using System.Collections;

public class lasso : MonoBehaviour {

	public int deathDist = 30;
	public Vector3 startingpos;
	// Use this for initialization
	void Start () {
		startingpos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (startingpos, this.transform.position) > deathDist) {
			GameController.control.lassoFlag = false;
			Destroy(gameObject);
		}
	}
}
