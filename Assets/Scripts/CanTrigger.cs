using UnityEngine;
using UnityEngine.Events;

public class CanTrigger : MonoBehaviour
{
    public string TrashTag;
    public UnityEvent<GameObject> OnThrown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TrashTag))
        {
            OnThrown.Invoke(other.gameObject);
        }
    }
}