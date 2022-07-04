using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IBoostHandler
{
    [SerializeField] FieldToProtect _protectedField;
    [SerializeField] PlayField _field;
    [SerializeField] UIController _UI;
    [SerializeField] Sounds _sounds;
    private InputSystem _input;

    private void Awake()
    {
        _input = new PCInput();
        _input.OnEnemyClicked += HandleTouch;
        _input.OnBoostClicked += HandleBoost;

        _protectedField.OnLost += HandleDefeat;
    }

    private void HandleTouch(ITouchable touched)
    {
        touched.HandleTouch();
    }

    private void HandleBoost(Boost boost)
    {
        boost.MakeBoost(this);
        _sounds.PlayBoostCollect();
    }

    private void HandleDefeat()
    {
        _field.StopCreatingEnemies();
        _UI.ActivateRestart();
        _sounds.PlayLose();
    }

    void Update()
    {
        _input.Update();   
    }

    public void MakeFreezeBoost()
    {
        StartCoroutine(_field.Freeze(5));
    }

    public void MakeClearBoost()
    {
        _protectedField.Clear();
    }
}
