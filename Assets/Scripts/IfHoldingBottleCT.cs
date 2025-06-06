using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class IfHoldingBottleCT : ConditionTask {

		public GameObject bottleHolder;
		bool playerMode;
		Player player;
		WetBully wetBully;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			player = bottleHolder.GetComponent<Player>();
			playerMode = true;
			if (player == null)
			{
				playerMode = false;
				wetBully = bottleHolder.GetComponent<WetBully>();
			}
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
			if (playerMode)
			{
                return player.holdingBottle;
            } else
			{
				return wetBully.holdingBottle;
			}
        }
	}
}