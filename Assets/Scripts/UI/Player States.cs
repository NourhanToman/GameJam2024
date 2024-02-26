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
    private float _oxygenDecreasedRate;
    public float _oxygenTimer = 100;
    public float _decreaseInterval = 1f;
    public float _outOfAirDamage = 25f;
    public GameObject _pool;
    private bool isDrowning = false;
    private bool isSuffocating = false;

    private void Awake()
    {
       Instance= this;
    }

    void Start()
    {
        if (GameManager.Instance.attempts == RoomsAttempts.TWO)
        {
            _oxygenDecreasedRate = 8f;
        }

        if(GameManager.Instance.attempts == RoomsAttempts.THREE)
        {
            _oxygenDecreasedRate = 1f;
        }

        if (GameManager.Instance.attempts == RoomsAttempts.ONE)
        {
            _oxygenDecreasedRate = 15f;
        }

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
       /* if (GameManager.Instance.state == GameStates.Freedom)
        {*/
           // Debug.Log("Freedom");
        if (_pool != null)
        {
            if (_camera.transform.position.y - _pool.transform.position.y <= 0f)
            {
                isDrowning = true;
            }
            else
            {
                isDrowning = false;
            }
        }

        if(GameManager.Instance.state == GameStates.Peace)
        {
           // Debug.Log("Peace");
            isSuffocating = true;
        }
        else
        {
            isSuffocating = false;
        }


            if (isDrowning || isSuffocating)
            {
                _oxygenTimer += Time.deltaTime;
                if (_oxygenTimer >= _decreaseInterval)
                {
                    DecreaseOxygen();
                    _oxygenTimer = 0;
                }
            }

        if (_pool != null)
        {
            if (isDrowning == false)
            {
                _currentHealth = Mathf.Lerp(_currentHealth, _maxHealth, Time.deltaTime);
                if (vignette != null)
                {
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, Time.deltaTime * 0.4f);
                }
            }
        }
            Debug.Log("Before");
            if ((isDrowning && _currentHealth < 100) || (isSuffocating && _currentHealth < 100))
            {
                Debug.Log((isSuffocating && _currentHealth < 100));
                if (vignette != null)
                {
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, Time.deltaTime * 0.6f);
                }
                if (_currentHealth <= 0)
                {

                    switch (GameManager.Instance.playerState) 
                    {
                        case PlayerState.NotFree: GameManager.Instance.UpdateRoomsRequirements(roomsRequirments.none); break;
                        case PlayerState.NoHandCuf: GameManager.Instance.UpdateRoomsRequirements(roomsRequirments.FreedomPortal); break;
                        case PlayerState.NoCamShake: GameManager.Instance.UpdateRoomsRequirements(roomsRequirments.JusticePortal); break;
                    }
                  GameManager.Instance.UpdateGameState(GameStates.Trail);
                }
            }
    }
 

}




