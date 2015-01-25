using UnityEngine;
using System.Collections;

public class DragonRun : MonoBehaviour {

	private Animation dragon;
	public Rigidbody FireBall;
	private float nextfireshots;
	private bool swap;
	// Use this for initialization
	void Start () {
		nextfireshots = 2.5f;
		dragon = GetComponent<Animation> ();
		swap = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (dragon ["DragonLoop"].time > nextfireshots) {
			shootFire(this.transform.position, this.transform.rotation);
			Debug.Log (swap.ToString ());
			if(swap){
				nextfireshots+= 5f;
				swap = false;
			}else{
				nextfireshots+= 7f;
				swap = true;
			}
		}
	}

	void shootFire(Vector3 pos, Quaternion direction){

		for (int i = 0; i <= 10; i++){

			Rigidbody fireball;
			fireball = (Rigidbody) Instantiate(FireBall,pos+new Vector3((Random.value*50)-25,40,0), direction);
			
			fireball.velocity = fireball.transform.forward * 50;
			
			
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag.Equals ("PlayerAttack"))
						gameObject.SetActive (false);

		

	}

}
