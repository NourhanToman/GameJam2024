using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates Instance { get; private set; }

    public float _currentHealth;
    public float _maxHealth;

    public float _currentOxygenPercent;
    public float _maxOxygenPercent = 100;
    public float _oxygenDecreasedRate = 1f;
    public float _oxygenTimer = 100;
    public float _decreaseInterval = 1f;
    public float _outOfAirDamage = 5f;

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

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _currentOxygenPercent = _maxOxygenPercent;

    }

    private void DecreaseOxygen()
    {
        _currentOxygenPercent -= _oxygenDecreasedRate * _decreaseInterval;
        if(_currentOxygenPercent < 0)
        {
            _currentOxygenPercent = 0;
            SetHealth(_currentHealth - _outOfAirDamage);
        }
    }

    public void SetHealth(float health)
    {
        _currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        /*
           Rokaia logic of water
           if(7aga t3rfo hwa t7t el maya aw fe room el peace abl ma y7l el rooms el 2wlanya)
           {
              _oxygenTimer = Time.deltaTime;
              if(_oxygenTimer >= _decreaseInterval) 
              {
                  DecreaseOxygen();
                  _oxygenTimer = 0;
              }
           }

           //23mli resst lel oxygen lma el player ytl3 mn el maya aw ytl3 mn el peace room:
            PlayerStates.Instance._currentOxygenPercent = PlayerStates.Instance._maxOxygenPercent;
         */

        /*
            Nourhan logic el health 
            lma el y7sl 7aga el camera vienette yzdad bnfs 3aded el health el hyn2so we byt3ml reset b3d 5 swany msln lw m5ad4 damage
         */
    }
}
