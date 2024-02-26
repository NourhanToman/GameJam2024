using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavier : InteractableBase
{
    [SerializeField] Transform waterTransform;
    [SerializeField] float risingDuration;
    [SerializeField] float loweringDuration;
    [SerializeField] float highWaterLevel;// Desired Y position for water
    private float lowerWaterLevel;
    private bool isRising;
    private bool isLowering;

    private void Start()
    {
        lowerWaterLevel = waterTransform.position.y;
        Rise();
    }
    public override void OnInteract()
    {
        base.OnInteract();
        lowerWaterLevel = waterTransform.position.y;
        Lower();
    }
    void Update()
    {

    }
    public void Rise()
    {
        AudioManager.instance.LoopPlay(AudioType.SFX, "Water");
        StartCoroutine("StartRise");
    }
    public void Lower()
    {
        AudioManager.instance.LoopStop(AudioType.SFX, "Water");
        StartCoroutine("startLowering");
    }
    private IEnumerator StartRise()
    {
        if (isRising)
        {
            yield break;
        }

        isRising = true;
        float counter = 0;

        while (counter < risingDuration)
        {
            counter += Time.deltaTime;
            waterTransform.position = Vector3.Lerp(waterTransform.position, new Vector3(waterTransform.position.x, highWaterLevel, waterTransform.position.z), counter / risingDuration);
            yield return null;
        }
        isLowering = false;
        
    }
    private IEnumerator startLowering()
    {
        if (isLowering)
        {
            yield break;
        }

        isLowering = true;
        float counter = 0;

        while (counter < loweringDuration)
        {
            counter += Time.deltaTime;
            waterTransform.position = Vector3.Lerp(waterTransform.position, new Vector3(waterTransform.position.x, lowerWaterLevel, waterTransform.position.z), counter / loweringDuration);
            yield return null;
        }
        risingDuration = 0;
        isRising = false;
        
    }
}
