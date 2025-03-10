using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipDriver : MonoBehaviour
{
    public XRLever Brakes;
    public XRKnob Wheel;

    public float MovementSpeed;
    public float SteeringSpeed;

    private Transform _self;
    private bool _isOn;

    private void Awake()
    {
        _self = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float movementVelocity = (Brakes.value ? 1 : 0) * MovementSpeed;
        float steeringVelocity = (Brakes.value ? 1 : 0) * SteeringSpeed * Mathf.Lerp(-1, 1, Wheel.value);
        Vector3 velocity = new Vector3(steeringVelocity, 0, movementVelocity);
        _self.position += velocity * Time.deltaTime;
        
        if (Brakes.value != _isOn)
        {
            if (Brakes.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }
        _isOn = Brakes.value;
    }
}