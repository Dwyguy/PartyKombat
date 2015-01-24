using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController control;

	public short currentKid;
	public GameObject [] refKids;

	void Awake(){

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
}
