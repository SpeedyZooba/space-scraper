using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    public ParticleSystem RayParticle;
    public Transform RaySource;
    private const float _distance = 10;
    private bool _isActive;

    private void Awake()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(StartShooting);
        grabInteractable.deactivated.AddListener(StopShooting);
    }

    private void Update()
    {
        if (_isActive)
        {
            CheckShot();
        }
    }

    private void StartShooting(ActivateEventArgs arg0)
    {
        AudioManager.instance.Play("Pistol");
        RayParticle.Play();
        _isActive = true;
    }

    private void StopShooting(DeactivateEventArgs arg0)
    {
        AudioManager.instance.Stop("Pistol");
        RayParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _isActive = false;
    }

    private void CheckShot()
    {
        if (Physics.Raycast(RaySource.position, RaySource.forward, out RaycastHit hit, _distance))
        {
            if (hit.transform.CompareTag("Breakable"))
            {
                BreakableObject obj = hit.transform.GetComponent<BreakableObject>();
                obj.Break();
            }
        }
    }
}