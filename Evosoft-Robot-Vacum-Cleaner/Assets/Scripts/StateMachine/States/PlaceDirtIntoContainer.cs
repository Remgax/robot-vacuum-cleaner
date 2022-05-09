using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDirtIntoContainer : IState
{
    private readonly Robot _robot;
    public PlaceDirtIntoContainer(Robot robot) 
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
        if (_robot.Take())
        {
            _robot.RobotBase.Add();
        }
    }
}
