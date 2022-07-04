using UnityEngine;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    public float Speed => _speed;

    [SerializeField] private int _health;
    public int Health => _health;
}
