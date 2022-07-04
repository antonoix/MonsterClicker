using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldToProtect : MonoBehaviour
{
    public event Action OnLost;
    [SerializeField] private List<Enemy> _enemies;
    private const int _maxEnemiesCount = 10;

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }

    public void Clear()
    {
        while (_enemies.Count > 0)
        {
            _enemies[0].Kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            _enemies.Add(enemy);
            enemy.OnDied += (Enemy en) => _enemies.Remove(en);
            CheckIfLost();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
            _enemies.Remove(enemy);
    }

    private void CheckIfLost()
    {
        if (_enemies.Count >= _maxEnemiesCount)
            OnLost?.Invoke();
    }
}
