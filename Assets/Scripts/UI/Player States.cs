using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates Instance { get; private set; }
    private Volume volume;
    private Vignette vignette;
    private Camera _camera;

    public float _currentHealth;
    public float _maxHealth;

    public float _currentOxygenPercent;
    public float _maxOxygenPercent = 100;
    public float _oxygenDecreasedRate = 10f;
    public float _oxygenTimer = 100;
    public float _decreaseInterval = 1f;
    public float _outOfAirDamage = 25f;
    public GameObject _pool;
    private bool isDrowning = false;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _currentHealth = _maxHealth;
        _currentOxygenPercent = _maxOxygenPercent;
        _camera = Camera.main;
        volume = _camera.GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    private void DecreaseOxygen()
    {
        _currentOxygenPercent -= _oxygenDecreasedRate * _decreaseInterval;
        if(_currentOxygenPercent <= 0)
        {
            _currentOxygenPercent = 0;
            SetHealth(_currentHealth - _outOfAirDamage);
        }
    }

    public void SetHealth(float health)
    {
        _currentHealth = health;
    }

 
    void Update()
    {        
        if (_camera.transform.position.y - _pool.transform.position.y <= 0f)
        {
            isDrowning = true;
        }
        else 
        {
            isDrowning = false;
        }
        
        if (isDrowning)
        {
            _oxygenTimer += Time.deltaTime;
            if (_oxygenTimer >= _decreaseInterval)
            {
                DecreaseOxygen();
                _oxygenTimer = 0;
            }
        }

        /*if (GameManager.Instance.state == GameStates.Peace || GameManager.Instance.state == GameStates.Freedom)
        {
            Debug.Log("can");
        }
        else
        {
            PlayerStates.Instance._currentOxygenPercent = PlayerStates.Instance._maxOxygenPercent;
        }*/

        if (isDrowning == false)
        {
            _currentHealth = Mathf.Lerp(_currentHealth, _maxHealth, Time.deltaTime); 
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, Time.deltaTime*0.1f);
            }
        }

        if (isDrowning && _currentHealth <= 0)
        {    
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, Time.deltaTime*0.1f); 
            }
            if (_currentHealth <= 0)
            {
                GameManager.Instance.UpdateRoomsRequirements(roomsRequirments.none);
                GameManager.Instance.UpdateGameState(GameStates.Trail);
            }
        }
    }



}
