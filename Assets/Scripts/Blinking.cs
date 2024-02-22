using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Blinking : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public float lerpDuration1 = 1f; 
    private float currentLerpTime1 = 0f;

    public float lerpDuration2 = 0.6f;
    private float currentLerpTime2 = 0f;

    public float lerpDuration3 = 1;
    private float currentLerpTime3 = 0f;

    private Volume volume;
    private Vignette vignette;

    private void Start()
    {
        camera = Camera.main;
        volume = camera.GetComponent<Volume>();
        Blink();

    }


    public void Blink()
    {
        if (volume != null && volume.profile.TryGet(out vignette))
        {
            StartCoroutine(LerpOneToHalf());

        }
        else
        {
            Debug.LogError("Post Processing Volume or Vignette not found!");
        }
    }


    private IEnumerator LerpOneToHalf()
    {
        float startIntensity = 1f;
        float targetIntensity = 0.3f;

        while (currentLerpTime1 < lerpDuration1)
        {
            currentLerpTime1 += Time.deltaTime;

            float t = currentLerpTime1 / lerpDuration1;
            vignette.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t);

            yield return null;

        }

        vignette.intensity.value = targetIntensity;
        StartCoroutine(LerpHalfToOne());
    }

    private IEnumerator LerpHalfToOne()
    {
        float startIntensity = 0.3f;
        float targetIntensity = 0.6f;

        while (currentLerpTime2 < lerpDuration2)
        {
            currentLerpTime2 += Time.deltaTime;

            float t = currentLerpTime2 / lerpDuration2;
            vignette.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t);

            yield return null;
        }

        vignette.intensity.value = targetIntensity;
        StartCoroutine(LerpToFull());
    }

    private IEnumerator LerpToFull()
    {
        float startIntensity = 0.6f;
        float targetIntensity = 0f;

        while (currentLerpTime3 < lerpDuration2)
        {
            currentLerpTime3 += Time.deltaTime;

            float t = currentLerpTime3 / lerpDuration3;
            vignette.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t);

            yield return null;
        }

        vignette.intensity.value = targetIntensity;
    }


}
