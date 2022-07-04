using System;
using UnityEngine;

public abstract class InputSystem
{
    public event Action<ITouchable> OnEnemyClicked;
    public event Action<Boost> OnBoostClicked;


    protected readonly Camera _cam = Camera.main;
    private const float _defaultDistance = 20;

    public virtual void Update()
    {
        if (CheckIfClicked())
        {
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent<ITouchable>(out var touched))
                    OnEnemyClicked?.Invoke(touched);
                if (hit.transform.TryGetComponent<Boost>(out var boost))
                    OnBoostClicked?.Invoke(boost);
            }
        }
    }

    protected abstract bool CheckIfClicked();
}
