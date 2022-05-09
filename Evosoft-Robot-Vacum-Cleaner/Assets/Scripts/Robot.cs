using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    public event Action<int> OnGatheredChanged;
    [SerializeField] private int _tankCapacity = 10;
    private StateMachine _stateMachine;
    private int _gathered;
    public Dirty Target { get; set; }
    public Base RobotBase { get; set; }

    private void Awake()
    {
        var navMeshAgent = GetComponent<NavMeshAgent>();

        _stateMachine = new StateMachine();

        var search = new SearchForDirt(this);
        var moveToSelected = new MoveToSelected(this, navMeshAgent);
        var gather = new GatherDirt(this);
        var returnToBase = new ReturnToBase(this, navMeshAgent);
        var placeDirtIntoGarbageContiner = new PlaceDirtIntoContainer(this);

  
        AddTransition(search, moveToSelected, HasTarget());
        AddTransition(moveToSelected, search, Stuck());
        AddTransition(moveToSelected, gather, ReachedDestination());
        AddTransition(gather, search, TargetIsGatherdAndTankIsNotFull());
        AddTransition(gather,returnToBase, TankFull());
        AddTransition(returnToBase, placeDirtIntoGarbageContiner, ReachedBase());
        AddTransition(placeDirtIntoGarbageContiner, search, () => _gathered == 0);

        void AddTransition(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
        Func<bool> HasTarget() => () => Target != null;
        Func<bool> Stuck() => () => moveToSelected.TimeStuck > 1f;
        Func<bool> ReachedDestination() => () => Target != null
       && Vector3.Distance(transform.position, Target.transform.position) < 1f;
        Func<bool> TargetIsGatherdAndTankIsNotFull() => () => (Target == null || Target.IsGathered) && !TankFull().Invoke();
        Func<bool> TankFull() => () => _gathered >= _tankCapacity;
        Func<bool> ReachedBase() => () => RobotBase != null
          && Vector3.Distance(transform.position, RobotBase.transform.position) < 1f;

        _stateMachine.SetState(search);

    }


    private void Update() => _stateMachine.Tick();

    public void TakeFromTarget()
    {
        if (Target.Take())
        {
            Debug.Log("Take Method in Robot");
            _gathered++;
            OnGatheredChanged?.Invoke(_gathered);
        }
    }

    public bool Take()
    {
        if (_gathered <= 0)
            return false;

        _gathered--;
        OnGatheredChanged?.Invoke(_gathered);
        return true;
    }

}
