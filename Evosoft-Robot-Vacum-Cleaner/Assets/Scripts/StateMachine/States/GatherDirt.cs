using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherDirt : IState
{
    private readonly Robot _robot;
    private float _gatheredPerSecound = 3;

    private float _nextTakeGatherTime;

    public GatherDirt(Robot robot)
    {
        _robot = robot;
    }
    public void OnEnter()
    {
       
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
        if(_robot.Target != null) 
        {
            if (_nextTakeGatherTime <= Time.time)
            {
                _nextTakeGatherTime = Time.time + (1f / _gatheredPerSecound);
                _robot.TakeFromTarget();
            }
        }
    }
}
