using UnityEngine;
using System.Collections;

public class FlyNest : EventBase
{
    public override void EventBehavior()
    {
        if(Active == false)
        {
            Active = !Active;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
