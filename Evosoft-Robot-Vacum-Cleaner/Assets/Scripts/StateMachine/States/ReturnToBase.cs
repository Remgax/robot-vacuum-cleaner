using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnToBase : IState
{
    private readonly Robot _robot;
    private readonly NavMeshAgent _navMeshAgent;

    public ReturnToBase(Robot robot,NavMeshAgent navMeshAgent)
    {
        _robot = robot; 
        _navMeshAgent = navMeshAgent;   
    }

    public void OnEnter()
    {
        _robot.RobotBase = Object.FindObjectOfType<Base>();
        _navMeshAgent.enabled = true;   
        _navMeshAgent.SetDestination(_robot.RobotBase.transform.position);
    }

    public void OnExit()
    {
        _navMeshAgent.enabled = false;  
    }

    public void Tick()
    {
    }
}
