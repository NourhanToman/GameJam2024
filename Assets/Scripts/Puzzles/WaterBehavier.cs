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
        lowerWaterLevel = transform.position.y;
        Rise();
    }
    public override void OnInteract()
    {
        lowerWaterLevel = transform.position.y;
        Lower();
    }
    void Update()
    {

    }
    public void Rise()
    {
        StartCoroutine("StartRise");
    }
    public void Lower()
    {
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,highWaterLevel, transform.position.z), counter / risingDuration);
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,lowerWaterLevel,transform.position.z), counter / loweringDuration);
            yield return null;
        }
        isLowering = false;
    }
}
