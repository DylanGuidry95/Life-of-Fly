using UnityEngine;
using System.Collections;

public class FlyNest : EventBase
{
    public override void EventBehavior()
    {
        if(Active == false)
        {
            Active = !Active;
            BoidBehavior b = Instantiate(Resources.Load("FlyBoid", typeof(BoidBehavior))) as BoidBehavior;
            b.transform.parent = transform;
            b.transform.localScale *= .1f;
            b.transform.localPosition = Vector3.zero;
        }
    }
}
