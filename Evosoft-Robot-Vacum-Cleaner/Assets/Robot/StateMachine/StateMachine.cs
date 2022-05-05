using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();


    public void AddTransition(IState fromState, IState toState, Func<bool> condition)
    {
        if (_transitions.TryGetValue(fromState.GetType(), out var transitions) == false)
        {
            transitions = new List<Transition>();
            _transitions[fromState.GetType()] = transitions;
        }
        transitions.Add(new Transition(toState, condition));
    }
}
