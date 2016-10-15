using UnityEngine;
using System.Collections;

public class EventSample : EventBase
{
    public override void EventBehavior()
    {
        Active = !Active;
        GetComponent<Renderer>().material.color = (Active) ? Color.red : Color.white;
    }
}
