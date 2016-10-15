using UnityEngine;
using System.Collections;

public class EnviormentEvents : MonoBehaviour
{
    /// <summary>
    /// Starts the event that is triggered when the appropriate condition is met
    /// </summary>
    public void StartEvent()
    {
        foreach (EventBase eb in EventActions) //Loops through each EventBase in the EventActions script
        {
            eb.EventBehavior(); //Invokes the EventBehavior function from the EventBase script attached to this object
        }
    }

    void Awake()
    {
        if (GetEvents() == -1 || GetEvents() == 0) //If the return value of GetEvents is -1 or 0
            Debug.LogError("No events found with in children of this object"); //Display error that says no events where found
    }

    /// <summary>
    /// Searchs all of the components attached to the object for components of type EventBase
    /// and as they are found we will add them to the EventActions list
    /// </summary>
    /// <returns></returns>
    int GetEvents()
    {
        EventActions = new System.Collections.Generic.List<EventBase>(); //News up the list of EventBase components
        EventBase[] events = GetComponents<EventBase>(); //Creates a new array with the data from the GetComponents of type EventBase
        if (events.Length == 0 || events == null) //If events array's length is equal to zero or is null
            return -1; //returns -1
        foreach(EventBase eb in events) //Loops through each EventBase in the events array
        {
            EventActions.Add(eb); //Adds eb to the EventActions list
        }
        return (EventActions.Count != 0 | EventActions != null) ? 1 : 0; //If the count of EventActions is not equal to zero or EventActions is not null we return 1 else we return 0
    }

    [SerializeField]
    private System.Collections.Generic.List<EventBase> EventActions;
}
