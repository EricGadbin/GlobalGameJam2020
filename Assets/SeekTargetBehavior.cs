using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTargetBehavior : StateMachineBehaviour
{
    TeamComponent team = null;
    RobotControllerComponent controller = null;
    PathFollowComponent pathFollow;
    SensorComponent sensor = null;
    Animator animator = null;

    // Si y'a le player, target
    // Sinon Si y'a des enemies, target
    // Sinon target Base

    //Réf player -> equipe
    //Ref tous les robots de l'équipe adverse -> Equipe
    //Ref sur la base adverse -> equipe

    //Quand un robot entre en jeu, recalculer IA dans sa portée
    //Détection trigger pour le player 

    void WalkToFind()
    {
        List<TeamComponent> enemyTeam = team.GetEnemies();
        GameObject closestEnemy = null;
        
        foreach (TeamComponent enemy in enemyTeam)
        {
            if (enemy.tag == "Robot" && enemy.enabled) {
                if (closestEnemy) {
                    float actualClosest = Vector2.Distance(closestEnemy.transform.position, controller.transform.position);
                    float newClosest = Vector2.Distance(enemy.transform.position, controller.transform.position);

                    if (newClosest > actualClosest) {
                        closestEnemy = enemy.gameObject;    
                    }
                } else {
                    closestEnemy = enemy.gameObject;
                }
            }
        }
        if (closestEnemy) {
            pathFollow.SeekPath(closestEnemy.transform.position);
        } else {
            TeamComponent playerBase = enemyTeam.Find(item => item.tag == "Base");

            if (!playerBase)
                throw new System.Exception("Missing base target for AI " + animator.name);
            Vector2 basePos = playerBase.transform.position;
            basePos.y = animator.transform.position.y;
            pathFollow.SeekPath(basePos);
        }
    }

    bool SeekPlayer(List<GameObject> nearestEnemies)
    {
        GameObject player = nearestEnemies.Find(item => item.tag == "Player");
        
        if (player) {
            controller.AcquireTarget(player);
            animator.SetBool("HasTarget", true);
            return true;
        }
        return false;
    }

    bool SeekEnemy(List<GameObject> nearestEnemies)
    {
        GameObject closestEnemy = null;
        
        foreach (GameObject enemy in nearestEnemies)
        {
            //Debug.Log("Seek : " + enemy.name);
            if (enemy.tag == "Robot" && enemy.GetComponent<TeamComponent>().enabled) {
                if (closestEnemy) {
                    float actualClosest = Vector2.Distance(closestEnemy.transform.position, controller.transform.position);
                    float newClosest = Vector2.Distance(enemy.transform.position, controller.transform.position);

                    if (newClosest > actualClosest) {
                        closestEnemy = enemy;    
                    }
                } else {
                    closestEnemy = enemy;
                }
            }
        }

        if (closestEnemy) {
            //Debug.Log("Found enemy : " + closestEnemy.name);
            controller.AcquireTarget(closestEnemy);
            animator.SetBool("HasTarget", true);
            return true;
        }
        return false;
    }

    bool SeekBase(List<GameObject> nearestEnemies)
    {
        GameObject lab = nearestEnemies.Find(item => item.tag == "Base");

        if (lab) {
            controller.AcquireTarget(lab);
            animator.SetBool("HasTarget", true);
            return true;
        }
        return false;
    }

    void SeekNewTarget()
    {
        List<GameObject> enemies = sensor.detectedEntities;
        
        if (enemies.Count != 0) {
            if (SeekPlayer(enemies) == true) {
                //Debug.Log("SeekPlayer OK");
                return;
            }
            if (SeekEnemy(enemies) == true) {
                //Debug.Log("SeekEnemy OK");
                return;
            }
            if (SeekBase(enemies) == true) {
                //Debug.Log("SeekBase OK");
                return;
            }
        }

        //Debug.Log("Walk to find");
        WalkToFind();
    }




    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("SeekTarget");
        team = animator.GetComponent<TeamComponent>();
        controller = animator.GetComponent<RobotControllerComponent>();
        sensor = animator.GetComponentInChildren<SensorComponent>();
        pathFollow = animator.GetComponent<PathFollowComponent>();
        if (!pathFollow)
            throw new System.Exception("Missing pathFollow");
        this.animator = animator;
        sensor.OnSensorTriggered.AddListener(SeekNewTarget);
        SeekNewTarget();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
