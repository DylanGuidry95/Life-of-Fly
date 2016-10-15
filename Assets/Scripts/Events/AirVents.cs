using UnityEngine;
using System.Collections;

public class AirVents : EventBase
{    
	public override void EventBehavior()
    {
        Active = !Active;
        BlowAir(Active);
    }

    void BlowAir(bool state)
    {
        if (state)
            Debug.Log("Blowing Air");
        Debug.Log("System off");
    }
}
