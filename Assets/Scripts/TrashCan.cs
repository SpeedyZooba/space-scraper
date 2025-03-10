using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public void TrashThrown(GameObject trash)
    {
        trash.SetActive(false);
    }

    private void Awake()
    {
        GetComponent<CanTrigger>().OnThrown.AddListener(TrashThrown);
    }
}