using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _activeTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();
    private static List<Transition> _emptyTransitions = new List<Transition>(0);
    public void Tick() 
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To);

        _currentState?.Tick();
    }

    private Transition GetTransition()
    {
        foreach (var transition in _anyTransitions)
        {
            if(transition.Condition())
                return transition;
        }
        foreach (var transition in _activeTransitions)
        {
            if (transition.Condition())
                return transition;
        }
        return null;
    }

    public void SetState(IState state)
    {
       if(state == _currentState)
            return;

        _currentState?.OnExit();
        _currentState = state;

        _transitions.TryGetValue(_currentState.GetType(), out _activeTransitions);
        if (_activeTransitions == null) 
        {
            _activeTransitions = _emptyTransitions;
        }
        _currentState.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate) 
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false) 
        {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }
        transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate) 
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }
}