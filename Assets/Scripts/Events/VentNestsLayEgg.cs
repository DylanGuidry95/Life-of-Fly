using UnityEngine;
using System.Collections;

public class VentNestsLayEgg : EventBase
{
    public override void EventBehavior()
    {
        if (!Active && GetComponentInChildren<AirVents>().GetActvie == false)
        {
            Active = true;
            CreateFlies();
        }
    }

    void CreateFlies()
    {
        //Creates the flock of flies roaming around the nesting spot
        GetComponent<ParticleSystem>().Play();
    }
}
