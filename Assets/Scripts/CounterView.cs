using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMesh;
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
        _textMesh.text = _counter.Value.ToString();
    }
}