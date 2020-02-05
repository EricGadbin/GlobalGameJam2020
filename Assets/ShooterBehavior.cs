using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : StateMachineBehaviour
{
    private RobotControllerComponent controller = null;
    [SerializeField]
    private GameObject target = null;
    private ShotComponent gun = null;
    private SensorComponent sensor = null;
    Animator anim = null;

    public void OnSensorUpdate()
    {
        List<GameObject> enemies = sensor.detectedEntities;
        if (target) {
            if (!enemies.Contains(target) || (enemies.Count > 1 && target.tag == "Base")) {
                target = null;
                controller.AcquireTarget(target);
                anim.SetBool("HasTarget", false);
            }
        }
    }

    public void LoseTarget()
    {
        target = null;
        controller.AcquireTarget(target);
        anim.SetBool("HasTarget", false);
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("ShooterBehavior");
        anim = animator;
        controller = animator.GetComponent<RobotControllerComponent>();
        sensor = anim.GetComponentInChildren<SensorComponent>();
        sensor.OnSensorTriggered.AddListener(OnSensorUpdate);
        anim.GetComponent<PathFollowComponent>().StopAllCoroutines();
        target = controller.GetTarget();
        target.GetComponent<HealthComponent>().OnDeathEvent.AddListener(LoseTarget);
        animator.GetComponent<HealthComponent>().OnDeathEvent.AddListener(LoseTarget);
        //Récup la target
        //Add listener de la mort de la target

        gun = animator.GetComponent<ShotComponent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!target) {
            animator.SetBool("HasTarget", false);
        } else {
            Vector2 direction = target.transform.position - controller.transform.position;
            
            Debug.DrawRay(controller.transform.position, target.transform.position - controller.transform.position, Color.magenta);
            gun.Shoot(direction.normalized);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = null;
        controller.AcquireTarget(target);
    }

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
