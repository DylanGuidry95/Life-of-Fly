using UnityEngine;
using System.Collections;

public class AirVents : EventBase
{    
   public bool IsOn = true;
	public override void EventBehavior()
    {
        Active = !Active;
        BlowAir(Active);
    }

    void BlowAir(bool state)
    {
        IsOn = state;
        if (IsOn)
        {
            Debug.Log("System on" + name);
        }
        Debug.Log("System off" + name);
    }
}
