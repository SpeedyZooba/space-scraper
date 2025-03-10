using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorButton : MonoBehaviour
{
    public Animator DoorAnimator;
    private string _driverBool;

    private void Awake()
    {
        _driverBool = "open";
    }

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(ToggleDoor);
    }

    private void ToggleDoor(SelectEnterEventArgs args)
    {
        bool isOpen = DoorAnimator.GetBool(_driverBool);
        DoorAnimator.SetBool(_driverBool, !isOpen);
        AudioManager.instance.Play("Door");
    }
}