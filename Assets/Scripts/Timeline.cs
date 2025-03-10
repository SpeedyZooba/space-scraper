using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{
    public List<Step> Steps;
    private PlayableDirector _director;

    public void PlayStepAtIndex(int index)
    {
        Step step = Steps[index];
        if (!step.HasPlayed)
        {
            step.HasPlayed = true;
            _director.Stop();
            _director.time = step.Time;
            _director.Play();
        }
    }

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();        
    }
}
