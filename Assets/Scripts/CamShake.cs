using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamShake : MonoBehaviour
{


    /*public Vector3 startPosition = new Vector3(-0.1f, 0f, 0.1f);
    public Vector3 endPosition = new Vector3(0.1f, 0f, -0.1f);
    public float positionLerpSpeed = 1.5f;

    public Vector3 startRotation = new Vector3(0f, 0f, 3f);
    public Vector3 endRotation = new Vector3(0f, 0f, -3f);
    public float rotationLerpSpeed = 1.5f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Position Lerp
        float positionT = Mathf.PingPong(Time.time * positionLerpSpeed, 1f);
        Vector3 lerpedPosition = Vector3.Lerp(initialPosition + startPosition, initialPosition + endPosition, positionT);

        // Rotation Lerp
        float rotationT = Mathf.PingPong(Time.time * rotationLerpSpeed, 1f);
        Quaternion lerpedRotation = Quaternion.Euler(Vector3.Lerp(initialRotation.eulerAngles+startRotation, initialRotation.eulerAngles+endRotation, rotationT));

        // Apply lerped position and rotation
        transform.position = lerpedPosition;
        transform.rotation = lerpedRotation;
    }*/


    public Vector3 startPosition = new Vector3(-0.1f, 0f, 0.1f);
    public Vector3 endPosition = new Vector3(0.1f, 0f, -0.1f);
    public float lerpSpeed = 1.5f;
    private Vector3 initialPosition;

    public Vector3 startPosition2 = new Vector3(0.1f, 0f, -0.1f);
    public Vector3 endPosition2 = new Vector3(-0.1f, 0f, 0.1f);
    public float lerpSpeed2 = 1.5f;
    //private Vector3 initialPosition2;

   /* public Vector3 startRotation = new Vector3(0f, 0f, 3f);
    public Vector3 endRotation = new Vector3(0f, 0f, -3f);
    public float rotationLerpSpeed = 1.5f;
    private Quaternion initialRotation;*/

    private void Start()
    {
        initialPosition = transform.position;
       // initialRotation = transform.rotation;
    }

    void Update()
    {
        
        //float t1 = Mathf.PingPong(Time.time * lerpSpeed, 1f);
        transform.position = Vector3.Lerp(initialPosition + startPosition, initialPosition + endPosition, Time.deltaTime);
        initialPosition = transform.parent.position;
        transform.position = Vector3.Lerp(initialPosition - startPosition, initialPosition - endPosition, Time.deltaTime);


        /*float t2 = Mathf.PingPong(Time.time * lerpSpeed2, 1f);
        transform.position = Vector3.Lerp(initialPosition + startPosition2, initialPosition + endPosition2, t2);*/


        /*float t2 = Mathf.PingPong(Time.time * rotationLerpSpeed, 1f);
        transform.rotation = Quaternion.Euler(Vector3.Lerp(initialRotation.eulerAngles + startRotation, initialRotation.eulerAngles + endRotation, t2));*/


    }

    /*public Vector3 targetOffset = new Vector3(0.01f, 0f, 0.01f);
    public float lerpSpeed = 2f;

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position when the script starts
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the target position by adding the offset to the initial position
        Vector3 targetPosition = initialPosition + targetOffset;

        // Use Mathf.PingPong to create a smooth back-and-forth movement
        float t = Mathf.PingPong(Time.time * lerpSpeed, 1f);

        // Use Vector3.Lerp to smoothly move the object between initial and target positions
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    }*/


    /*  public Vector3 targetOffset = new Vector3(0.01f, 0f, 0.01f);
      //public Vector3 targetScale = new Vector3()
      public float lerpSpeed = 2f;

      void Update()
      {
          // Calculate the target position by adding the offset to the current position
          Vector3 targetPosition = transform.position + targetOffset;

          // Use Vector3.Lerp to smoothly move the object towards the target position
          transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
      }*/




    /*  public float rotationSpeed = 30f;
      public float moveSpeed = 2f;

      Vector3 newPos;
      Quaternion newRot;

      // Start is called before the first frame update
      void Start()
      {


          newPos = transform.position;
          newRot = transform.rotation;
      }


      // Update is called once per frame
      void Update()
      {
          //1
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;

          //2
          transform.position = newPos;

          //3
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;

          //4
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;

          //5
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;

          //6
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;


          //7
          newPos.x += -0.02f;
          newPos.z += -0.01f;
          newRot.z += -3f;
      }*/
}
