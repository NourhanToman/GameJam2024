using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private TextMeshProUGUI _OxygenCounter;

    private float _currentOxygen, _maxOxygen;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentOxygen = PlayerStates.Instance._currentOxygenPercent;
        _maxOxygen = PlayerStates.Instance._maxOxygenPercent;

        float _fillValue = _currentOxygen / _maxOxygen;
        _slider.value = _fillValue;

        _OxygenCounter.text = _currentOxygen + "%";
    }
}
