using UnityEngine;
using System.Collections;

public class HackBehave : StateMachineBehaviour {
    float startTime = -1;
    public string ressource = "Caillou12";
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        startTime = Time.time;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (startTime > 0 && Time.time > startTime + 0.2 && animator.GetBool("bro"))
        {
            ressource = "box_" + animator.GetInteger("lvl") + "_" + animator.GetInteger("num");
            Application.OpenURL("http://192.168.101.38/solutechackathon2016team3/Watch_graph/?object=" + ressource);
            startTime = -1;
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
