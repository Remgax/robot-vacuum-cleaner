using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class SearchForDirt : IState
{
    private readonly Robot _robot;

    public SearchForDirt(Robot robot)
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
        _robot.Target = FindNearestDirt(1);
    }

    private Dirty FindNearestDirt(int nearestNodes)
    {
        return Object.FindObjectsOfType<Dirty>()
            .OrderBy(t => Vector3.Distance(_robot.transform.position, t.transform.position))
            .Where(t => t.IsGathered == false)
            .Take(nearestNodes)
            .OrderBy(t => Random.Range(0,int.MaxValue))
            .FirstOrDefault();
    }
}
