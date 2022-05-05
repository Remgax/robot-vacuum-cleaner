using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
internal class Transition
{
    public Func<bool> Condition { get; }
    public IState TransitionTo { get; }
    public Transition(IState transitionTo, Func<bool> condition)
    {
        TransitionTo = transitionTo;
        Condition = condition;
    }
}