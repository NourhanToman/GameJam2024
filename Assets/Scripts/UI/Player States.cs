using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates Instance { get; private set; }
    [SerializeField] private Camera camera;
    private Volume volume;
    private Vignette vignette;


    public float _currentHealth;
    public float _maxHealth;

    public float _currentOxygenPercent;
    public float _maxOxygenPercent = 100;
    public float _oxygenDecreasedRate = 1f;
    public float _oxygenTimer = 100;
    public float _decreaseInterval = 1f;
    public float _outOfAirDamage = 5f;
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
        camera = Camera.main;
        volume = camera.GetComponent<Volume>();
        volume.profile.TryGet(out vignette);

    }

    private void DecreaseOxygen()
    {
        _currentOxygenPercent -= _oxygenDecreasedRate * _decreaseInterval;
        if(_currentOxygenPercent < 0)
        {
            Debug.Log(_currentOxygenPercent);
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
         if (isDrowning)
           {
            _oxygenTimer = Time.deltaTime;
            if (_oxygenTimer >= _decreaseInterval)
            {
                DecreaseOxygen();
                _oxygenTimer = 0;
            }
           }

        if (GameManager.Instance.state != GameStates.Peace)
            PlayerStates.Instance._currentOxygenPercent = PlayerStates.Instance._maxOxygenPercent;


        if (GameManager.Instance.state != GameStates.Freedom)
            PlayerStates.Instance._currentOxygenPercent = PlayerStates.Instance._maxOxygenPercent;

        if (!isDrowning)
        {
            _currentHealth = Mathf.Lerp(_currentHealth, _maxHealth, Time.deltaTime); 
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, Time.deltaTime);
            }
        }

        if (isDrowning)
        {
            _currentHealth = Mathf.Lerp(_maxHealth, _currentHealth, Time.deltaTime*0.05f);
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, Time.deltaTime*0.05f); 
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            
            isDrowning = true;

            Debug.Log("dROWN");
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isDrowning = false;
        }
    }
}
