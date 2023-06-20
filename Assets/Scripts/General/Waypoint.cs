using System;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> _currentEnemies;
    [SerializeField] private bool _isFinalWaypoint;

    public bool IsFinalWaypoint => _isFinalWaypoint;
    public int GetEnemiesCountInThisWaypoint => _currentEnemies.Count;
    public void RemoveEnemy(GameObject enemy)
    {
        _currentEnemies.Remove(enemy);
    }

    public void PrintEnemies()
    {
        Debug.Log($"Enemy count in this waypoint is: {_currentEnemies.Count}");
        foreach(var enemy in _currentEnemies)
        {
            Debug.Log(enemy.name);
        }
    }
}
