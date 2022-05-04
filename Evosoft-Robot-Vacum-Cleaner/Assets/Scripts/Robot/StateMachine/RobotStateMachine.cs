using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateMachine : MonoBehaviour
{
    RobotBaseState _curretState;
    RobotStateFactory _states;

    public RobotBaseState CurrentState { get { return _curretState; } set { _curretState = value; } }
    void Start()
    {

    }

    void Awake()
    {
        //setup state
        _states = new RobotStateFactory(this);
        _curretState = _states.Idle();
        _curretState.EnterState();
    }
    // Update is called once per frame
    void Update()
    {
        _curretState.UpdateState();
    }

    public void SwitchState(RobotBaseState state)
    {

    }
}
