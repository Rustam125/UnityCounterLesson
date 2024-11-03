using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _counterViewText;

    [SerializeField, Min(0.5f)]
    private float _secondsToIncrement = 0.5f;

    private int _counterValue;
    private bool _isNeedToIncrease;

    private void Start()
    {
        _counterValue = 0;
        _isNeedToIncrease = false;
        DisplayCounterValue(_counterValue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isNeedToIncrease = !_isNeedToIncrease;
            StartCoroutine(Count(_secondsToIncrement));
        }
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isNeedToIncrease)
        {
            _counterValue++;
            DisplayCounterValue(_counterValue);
            yield return wait;
        }
    }

    private void DisplayCounterValue(int value)
    {
        _counterViewText.text = value.ToString();
    }
}
