using StarterAssets;
using System.Collections;
using UnityEngine;

public class PeaceRoom : MonoBehaviour
{
    public GameObject portal;
    private void Start()
    {
        AudioManager.instance.Play(AudioType.Music, "Peace");
        AudioManager.instance.SFXLoop(AudioType.SFX, "Breathe");
        GameManager.Instance.Player = GameObject.FindWithTag("Player");
        GameManager.Instance.playerInputs = GameManager.Instance.Player.GetComponent<StarterAssetsInputs>();
        GameManager.Instance.cameraLock = GameManager.Instance.Player.GetComponent<CustomThirdPersonController>();

        portal.SetActive(false);
        if (GameManager.Instance.attempts == RoomsAttempts.ONE)
        {
            StartCoroutine(PlayerFirstVerse());
        }
        if (GameManager.Instance.attempts == RoomsAttempts.TWO)
        {
            StartCoroutine(PlayerSecondVerse());
        }
        if (GameManager.Instance.attempts == RoomsAttempts.THREE)
        {
            portal.SetActive(true);
            StartCoroutine(PlayerThirdVerse());
        }
    }

    private IEnumerator PlayerFirstVerse()
    {
        yield return new WaitForSeconds(5f);
        TextManger.instance.PlayMessage(2);
    }
    private IEnumerator PlayerSecondVerse()
    {
        yield return new WaitForSeconds(5f);
        TextManger.instance.PlayMessage(3);

    }
    private IEnumerator PlayerThirdVerse()
    {
        yield return new WaitForSeconds(5f);
        TextManger.instance.PlayMessage(4);

    }

   
}
