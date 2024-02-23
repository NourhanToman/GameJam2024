using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{

    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _OxygenCounter;

    private float _currentOxygen, _maxOxygen;

    private void Awake()
    {
        _fill = GetComponent<Image>();
    }
 
    private void Update()
    {
       
        _currentOxygen = PlayerStates.Instance._currentOxygenPercent;
        _maxOxygen = PlayerStates.Instance._maxOxygenPercent;

        float _fillValue = _currentOxygen / _maxOxygen;
        _fill.fillAmount = _fillValue;
        _OxygenCounter.text = _currentOxygen + "%";
    }
}
