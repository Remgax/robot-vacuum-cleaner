using UnityEngine;

public class RobotIdleState : RobotBaseState
{
    public RobotIdleState(RobotStateMachine curretContext, RobotStateFactory robotStateFactory)
    : base(curretContext, robotStateFactory) { }

    public override void CheckSwitchState()
    {
        throw new System.NotImplementedException();
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }
    public override void EnterState()
    {

    }
}
