public class RobotStateFactory
{

    RobotStateMachine _context;
    public RobotStateFactory(RobotStateMachine curretContext)
    {
        _context = curretContext;
    }

    public RobotBaseState Idle()
    {
        return new RobotIdleState(_context, this);
    }
    public RobotBaseState Move()
    {
        return new RobotMoveState(_context, this);
    }
    public RobotBaseState Clean()
    {
        return new RobotCleanState(_context, this);
    }
}
