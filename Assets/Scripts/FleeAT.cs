using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
namespace NodeCanvas.Tasks.Actions {

	public class FleeAT : ActionTask {

        NavMeshAgent navMeshAgent;
        public BBParameter<Transform> target;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            navMeshAgent.isStopped = false;
            Vector3 distance = agent.transform.position - target.value.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(agent.transform.position + distance, out hit, 1000, NavMesh.AllAreas);
            navMeshAgent.SetDestination(hit.position);
            EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}