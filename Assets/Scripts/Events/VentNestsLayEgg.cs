using UnityEngine;
using System.Collections;

public class VentNestsLayEgg : EventBase
{
    public override void EventBehavior()
    {
        if (!Active && GetComponent<AirVents>().GetActvie == false)
        {
            Active = true;
            CreateFlies();
        }
    }

    void CreateFlies()
    {
        //Creates the flock of flies roaming around the nesting spot
        Debug.Log("We got flies");
    }
}
