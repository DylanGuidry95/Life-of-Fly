using UnityEngine;
using System.Collections;

public class EventBase : MonoBehaviour
{
    protected bool Active = false;
    public virtual void EventBehavior()
    {
        Active = !Active;
        Debug.Log("Doing My Event");
    }

    public bool GetActvie { get { return Active; } }
}
