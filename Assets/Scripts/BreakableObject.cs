using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakableObject : MonoBehaviour
{
    public UnityEvent OnBreak;
    public List<GameObject> Pieces;
    public int BreakTime;
    private float _timer;

    public void Break()
    {
        _timer += Time.deltaTime;
        if (_timer >= BreakTime)
        {
            foreach (GameObject piece in Pieces)
            {
                piece.SetActive(true);
                piece.transform.parent = null;
            }
            OnBreak?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _timer = 0;
        foreach(GameObject piece in Pieces)
        {
            piece.SetActive(false);
        }
    }
}