using UnityEngine;
using System.Collections;

public class VentNestsLayEgg : EventBase
{
    public override void EventBehavior()
    {
        if (!GetComponentInChildren<AirVents>().IsOn)
        {
            Active = true;
            CreateFlies();
        }
    }

    void CreateFlies()
    {
        //Creates the flock of flies roaming around the nesting spot
        GetComponent<ParticleSystem>().Play();
        FindObjectOfType<ScoreSystem>().UpdateScore();
    }
}
