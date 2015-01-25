using UnityEngine;
using System.Collections;

public class DragonRun : MonoBehaviour {
	public Animator []dragon;


	// Use this for initialization
	void Start () {
		print ("DragonRun Script active");
		dragon = GetComponentsInChildren<Animator> ();
		dragon[0].SetBool ("Run", true);
		dragon[0].applyRootMotion = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
