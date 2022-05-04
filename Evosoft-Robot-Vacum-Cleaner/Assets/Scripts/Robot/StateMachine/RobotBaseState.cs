
using UnityEngine;

public abstract class RobotBaseState
{
    protected RobotStateMachine _context;
    protected RobotStateFactory _factory;
    public RobotBaseState(RobotStateMachine curretContext, RobotStateFactory robotStateFactory)
    {
        _context = curretContext;
        _factory = robotStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    void UpdateStates() { }
    protected void SwitchState(RobotBaseState newState)
    {
        // current state must be exited before new state
        ExitState();
        // new state will be called
        newState.EnterState();
        // switching current state of context
        _context.CurrentState = newState;
    }
}
