using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {
	private Animator animator; // The animator for the character
	// Use this for initialization
	void Start () {
	// this is a ref to the animator component on the root.

		//character = GetComponent<ThirdPersonCharacter>();
		animator = GetComponentInChildren<Animator>();



	}
	
	// Update is called once per frame
	void Update () {
		animator.applyRootMotion = true;
	}


	void OnTriggerEnter(Collider other)
	{Debug.Log ("Playerlook");
		if (other.tag == "Player") { 
			Debug.Log ("PlayerSpoted");
			if (!GameController.control.crouching){
			animator.SetTrigger("AttackTrigger");
			gameObject.tag = "KOAttack";
			}
		}
		
		
	}

	private void UpdateAnimator()
	{
		animator.applyRootMotion = true;

	}
}
