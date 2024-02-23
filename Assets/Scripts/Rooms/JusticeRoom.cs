using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JusticeRoom : MonoBehaviour
{
   // [SerializeField] ParticleSystem _scanner;
    [SerializeField] GameObject _scannerPrefab;
    [SerializeField] GameObject _parent;
    private float duration = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject _scanner = Instantiate(_scannerPrefab, _parent.transform.position,Quaternion.identity);
            ParticleSystem _scanParticle = _scanner.transform.GetChild(0).GetComponent<ParticleSystem>();

            var main = _scanParticle.main;
            main.startLifetime = 5;
            Destroy(_scanner,duration +1 );
        }


    }
}
