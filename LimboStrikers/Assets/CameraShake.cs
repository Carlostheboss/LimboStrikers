using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Transform transformCamera;
    public float shakeDuration;
    public float shakeMagnitude;
    public float dampingSpeed;
    private Vector2 initialPosition;

    public static CameraShake instance;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;

        Debug.Log(initialPosition);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        // initialPosition = transformCamera.localPosition;
       
    }

    void FixedUpdate()
    {
        Shake();
    }

    private void Update()
    {
        

    }

    void Shake()
    {
        if (shakeDuration > 0)
        {
            transformCamera.localPosition = initialPosition + Random.insideUnitCircle * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transformCamera.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float time, float force)
    {
        shakeDuration = time;
        shakeMagnitude = force;

}
}
