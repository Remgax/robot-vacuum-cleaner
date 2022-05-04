using UnityEngine;

public class RobotMoveState : RobotBaseState
{
    public RobotMoveState(RobotStateMachine curretContext, RobotStateFactory robotStateFactory)
    : base(curretContext, robotStateFactory) { }

    public override void CheckSwitchState()
    {
    }
    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }
    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

}
