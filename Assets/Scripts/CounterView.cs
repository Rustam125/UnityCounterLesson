using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _counterViewText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += DisplayCounterValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= DisplayCounterValue;
    }

    private void DisplayCounterValue()
    {
        _counterViewText.text = _counter.Value.ToString();
    }
}