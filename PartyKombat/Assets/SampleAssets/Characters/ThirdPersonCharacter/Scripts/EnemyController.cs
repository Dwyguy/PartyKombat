using UnityEngine;
using System.Collections;

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

		private Animator animator; // The animator for the character
		public Transform lookTarget { get; set; } // The point where the character will be looking at
		private Vector3 currentLookPos; // The current position where the character is looking
		public float lookBlendTime;
		public float lookWeight;
		
		// Use this for initialization
		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			//character = GetComponent<ThirdPersonCharacter>();
			animator = GetComponentInChildren<Animator>();
			startPos = this.transform.position;
			g = new GameObject ();
			getNewPositions();
			SetUpAnimator ();

			// give the look position a default in case the character is not under control
			currentLookPos = Camera.main.transform.position;
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

		private void updateAnimator(){

		}

		IEnumerator BlendLookWeight()
		{
			float t = 0f;
			while (t < lookBlendTime)
			{
				lookWeight = t / lookBlendTime;
				t += Time.deltaTime;
				yield return null;
			}
			lookWeight = 1f;
		}
		
		void OnEnable()
		{
			if (lookWeight == 0f)
			{
				StartCoroutine(BlendLookWeight());
			}
		}
		
		private void SetUpAnimator()
		{
			// this is a ref to the animator component on the root.
			animator = GetComponent<Animator>();
			
			// we use avatar from a child animator component if present
			// (this is to enable easy swapping of the character model as a child node)
			foreach (var childAnimator in GetComponentsInChildren<Animator>())
			{
				if (childAnimator != animator)
				{
					animator.avatar = childAnimator.avatar;
					Destroy(childAnimator);
					break;
				}
			}
		}

		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			rigidbody.rotation = animator.rootRotation;
			if (Time.deltaTime > 0)
			{
				Vector3 v = (animator.deltaPosition*1.2f)/Time.deltaTime;
				
				// we preserve the existing y part of the current velocity.
				v.y = rigidbody.velocity.y;
				rigidbody.velocity = v;
			}
		}

		private void UpdateAnimator()
		{
			// Here we tell the animator what to do based on the current states and inputs.
			if (attackMode) {
				animator.SetTrigger("Attack");
			}
			// only use root motion when on ground:
			//animator.applyRootMotion = onGround;
			
			// update the animator parameters
			animator.SetFloat("Forward", 1.0f, 0.1f, Time.deltaTime);
			animator.SetFloat("Turn", 1.0f, 0.1f, Time.deltaTime);
			//animator.SetBool ("Crouch", crouchInput);
			
			//animator.SetBool("OnGround", onGround);
			
			//animator.SetBool ("Push", false);
			
			/*switch((int)this.advancedSettings.characterID){
			case 1:
				//animator.SetBool("Push", primaryInput);
				break;
			default:
				break;
				
			}*/
			
			
			
			/*if (!onGround)
			{
				animator.SetFloat("Jump", velocity.y);
			}*/
			
			// calculate which leg is behind, so as to leave that leg trailing in the jump animation
			// (This code is reliant on the specific run cycle offset in our animations,
			// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
			/*float runCycle =
				Mathf.Repeat(
					animator.GetCurrentAnimatorStateInfo(0).normalizedTime + advancedSettings.runCycleLegOffset, 1);
			float jumpLeg = (runCycle < half ? 1 : -1)*forwardAmount;
			if (onGround)
			{
				animator.SetFloat("JumpLeg", jumpLeg);
			}*/
			
			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			
			//if (onGround && moveInput.magnitude > 0)
			//{
			//	animator.speed = animSpeedMultiplier;
			//}
			//else
			{
				// but we don't want to use that while airborne
				animator.speed = 1;
			}
		}

		
		private void OnAnimatorIK(int layerIndex)
		{
			// we set the weight so most of the look-turn is done with the head, not the body.
			animator.SetLookAtWeight(lookWeight, 0.2f, 2.5f);
			
			// if a transform is assigned as a look target, it overrides the vector lookPos value
			if (lookTarget != null)
			{
				currentLookPos = lookTarget.position;
			}
			
			// Used for the head look feature.
			animator.SetLookAtPosition(currentLookPos);
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
	
