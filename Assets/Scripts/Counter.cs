using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] [Min(0.5f)] private float _secondsToIncrement = 0.5f;

    private Coroutine _coroutine;
    private bool _isNeedToIncrease;

    public event Action ValueChanged;
    public int Value { get; private set; }

    private void Start()
    {
        Value = 0;
        ValueChanged?.Invoke();
        _isNeedToIncrease = false;
        RestartCoroutine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isNeedToIncrease = !_isNeedToIncrease;
            RestartCoroutine();
        }
    }

    private void RestartCoroutine()
    {
        _coroutine = StartCoroutine(Count(_secondsToIncrement));
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isNeedToIncrease)
        {
            Value++;
            ValueChanged?.Invoke();
            yield return wait;
        }
    }
}