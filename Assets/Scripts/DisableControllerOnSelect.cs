using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableControllerOnSelect : MonoBehaviour
{
    public GameObject LeftHandPrefab;
    public GameObject RightHandPrefab;

    private void Awake()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideController);
        grabInteractable.selectExited.AddListener(ShowController);
    }

    private void HideController(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.parent.CompareTag("Left Hand"))
        {
            LeftHandPrefab.SetActive(false);
        }
        if (args.interactorObject.transform.parent.CompareTag("Right Hand"))
        {
            RightHandPrefab.SetActive(false);
        }
    }

    private void ShowController(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.parent.CompareTag("Left Hand"))
        {
            LeftHandPrefab.SetActive(true);
        }
        if (args.interactorObject.transform.parent.CompareTag("Right Hand"))
        {
            RightHandPrefab.SetActive(true);
        }
    }
}