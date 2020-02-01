using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : StateMachineBehaviour
{
    private RobotControllerComponent controller = null;
    private RobotControllerComponent target = null;
    //private ShooterComponent gun = null;
    Animator anim = null;

    public void OnTargetDestroyed()
    {
        if (anim) {
            anim.SetBool("HasTarget", false);
            target = null;

        }
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        controller = animator.GetComponent<RobotControllerComponent>();
        target = controller.GetTarget();
        target.GetComponent<HealthComponent>().OnDeathEvent.AddListener(OnTargetDestroyed);
        //Récup la target
        //Add listener de la mort de la target

        // gun = animator.GetComponent<ShooterComponent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = target.transform.position - controller.transform.position;
    //    gun.Shoot(direction.normalized);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
