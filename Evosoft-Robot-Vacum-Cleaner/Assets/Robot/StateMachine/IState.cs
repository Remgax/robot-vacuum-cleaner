/// <summary>
/// IState interface represents a State and their behavior
/// </summary>
public interface IState
{
    void Tick();
    void OnEnter();
    void OnExit();
}
