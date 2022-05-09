using UnityEngine;
using UnityEngine.AI;

public class MoveToSelected : IState
{
    private readonly Robot _robot;
    private readonly NavMeshAgent _navMeshAgent;
    private Vector3 _lastPosition = Vector3.zero;

    public float TimeStuck;

    public MoveToSelected(Robot robot, NavMeshAgent navMeshAgent) 
    {
        _robot = robot; 
        _navMeshAgent = navMeshAgent;   
    }

    public void Tick()
    {
        if (Vector3.Distance(_robot.transform.position, _lastPosition) <= 0f)
            TimeStuck += Time.deltaTime;
        _lastPosition = _robot.transform.position;  
    }

    public void OnEnter()
    {
        TimeStuck = 0f;
        _navMeshAgent.enabled = true;
        _navMeshAgent.SetDestination(_robot.Target.transform.position);
    }

    public void OnExit()
    {
        _navMeshAgent.enabled = false;
    }
}
