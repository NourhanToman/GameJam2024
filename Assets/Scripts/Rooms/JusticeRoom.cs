using System.Collections;
using UnityEngine;

public class JusticeRoom : MonoBehaviour
{

    [SerializeField] GameObject _scannerPrefab;
    [SerializeField] GameObject _parent;
    private float duration = 5;
    private bool playONCE = true;
    private void Start()
    {
        
        if (GameManager.Instance.attempts == RoomsAttempts.ONE)
        {
            StartCoroutine(PlayerFirstVerse());
        }
    }


    private IEnumerator PlayerFirstVerse()
    {
        yield return new WaitForSeconds(5f);
        TextManger.instance.PlayMessage(7);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (playONCE)
            {
                TextManger.instance.PlayMessage(8);
                playONCE = false;
            }
            GameObject _scanner = Instantiate(_scannerPrefab, _parent.transform.position,Quaternion.identity);
            ParticleSystem _scanParticle = _scanner.transform.GetChild(0).GetComponent<ParticleSystem>();

            var main = _scanParticle.main;
            main.startLifetime = 5;
            Destroy(_scanner,duration +1 );
        }


    }
}
