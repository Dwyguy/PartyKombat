using UnityEngine;

namespace UnitySampleAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	//[RequireComponent(typeof (ThirdPersonCharacter))]
	public class EnemyController : MonoBehaviour
	{
		
		public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		protected Transform target; // target to aim for
		public float targetChangeTolerance = 1; // distance to target before target can be changed
		public Vector3 startPos;
		float roamRadius = 20.0f;
		private Vector3 targetPos;
		public float x, y, z;
		GameObject g;
		bool attackMode = false;
		
		// Use this for initialization
		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			//character = GetComponent<ThirdPersonCharacter>();
			startPos = this.transform.position;
			g = new GameObject ();
			getNewPositions();
		}
		
		private void Update()
		{
			if(target != null){
				if ((transform.position - targetPos).magnitude > 0.9) {
					targetPos = target.position;
					agent.SetDestination (targetPos);
						
					print ("target pos " + targetPos);
					print ("trans pos " + transform.position);
				} else {
					if(!attackMode)
					getNewPositions ();
				}
				agent.transform.position = transform.position;

			} else {
				getNewPositions();
			}
		}

		void getNewPositions(){
			//print ("startPos " + startPos);
			x = Random.Range(startPos.x-20, startPos.x+20);
			y = startPos.y;
			z = Random.Range (startPos.z-20, startPos.z+20);
			targetPos = new Vector3(x, y, z);
			agent.SetDestination (targetPos);
			g.transform.position = targetPos;
			target = g.transform;
			//print ("target pos " + targetPos);
		}

				
		void SetTarget(Transform target)
		{
			this.target = target;
		}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") { // AGGRO
				target = other.transform;
				targetPos = other.transform.position; // Get player
				attackMode = true;
		}
	}
}
	}
	
