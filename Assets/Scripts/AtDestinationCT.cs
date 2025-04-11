using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions {

	public class AtDestinationCT : ConditionTask {

        NavMeshAgent navMeshAgent;
        public BBParameter<Transform> target;
		public float detectRange;
		Rigidbody rb;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
			rb = agent.GetComponent<Rigidbody>();
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (Vector3.Distance(agent.transform.position, target.value.position) < detectRange)
			{
				navMeshAgent.isStopped = true;
				rb.velocity = Vector3.zero;
				return true;
			}
			return false;
		}
	}
}