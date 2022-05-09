using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class Base : MonoBehaviour
{
    [SerializeField] private int _maxCapacity = 100;
    private int _currentAmount;

    private void OnEnable()
    {
        _currentAmount = 0;
        Add();
    }
    public void Add() 
    {
        _currentAmount++;
        Debug.Log("Currently in the container:" + $"{_currentAmount}/{_maxCapacity}");
    }

}
