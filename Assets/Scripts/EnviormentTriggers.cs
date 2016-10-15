using UnityEngine;
using System.Collections;

public class EnviormentTriggers : MonoBehaviour
{
    void Awake()
    {
        if (GetAllObjectsWithEventTag() == -1) //If the return value of the GetAllObjectsWithEventTag function is -1
            Debug.LogError("No events found within the scene"); //Prints an error stating that there are no events in the scene found
        else if (GetAllObjectsWithEventTag() == 0) //If the return value of the GetAllObjectsWithEventTag function is 0
            Debug.LogError("No events found with tag " + EventTag); //Prints an error stating that there are no events with the same tag as the event tag
    }

    /// <summary>
    /// Searchs the current scene for all objects of type EnviormentEvents and if the tag of that object matches
    /// the EventTag variable we will add it to our Events list.
    /// If know object are found of type EnviormentEvents return -1 to denote no events are in the scene
    /// If objects are found we loop through the array of events and check each objects tag and if the tag matches
    /// the Event tag we add it to the Events list.
    /// If the Events list is emepty after the loop has completed we return 0 saying the no events found with the event tag
    /// If the list has at least one event in it we return 1 saying everything was found correctly
    /// </summary>
    /// <returns></returns>
    int GetAllObjectsWithEventTag()
    {
        Events = new System.Collections.Generic.List<EnviormentEvents>(); //News up the list of items
        EnviormentEvents[] eventArray = FindObjectsOfType<EnviormentEvents>(); //Creates a new array that copies the data from the FindObjectsOfType array
        if(eventArray.Length == 0 || eventArray == null) //Checks to see if there are any items in the array of if the array is null
        {
            return -1; //returns -1 to say no events are found in the current scene
        }
        foreach(EnviormentEvents e in eventArray) //Loops through each item in the event array
        {
            if(e.E_Tag == EventTag) //If e's tag matches the EventTag
            {
                Events.Add(e); //Add e to the Events list
            }
        }
        return (Events.Count != 0) ? 1 : 0; //Returns 1 if the list has at least one item in it and if it does not returns 0
    }

    /// <summary>
    /// When an object with a collider comes in contact with the object that has this script attached to it
    /// and if the tag on that object is equal to "Fly" we will Invoke the TriggerEvents function
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Fly")) //If col's tag equals "Fly"
        {
            TriggerEvents(); //Invokes the TriggerEvents function
        }
    }

    /// <summary>
    /// Loops through all of the events in the Events list and tries to trigger the events
    /// </summary>
    void TriggerEvents()
    {
        foreach(EnviormentEvents e in Events) //Loops through each EnviormentEvent in the Events list
        {
            e.StartEvent(); //Invokes the start event on the from the EnviormentEvents script attached to that object
        }
    }

    [SerializeField]
    private string EventTag = "Default"; //Tag for the object we are looking for

    [SerializeField]
    private System.Collections.Generic.List<EnviormentEvents> Events; //List of EnviormentEvents that will be triggered when and interactable item is hit

    [SerializeField]
    private float eventTriggerDelay; //Delay to check to see how long the player has been in contact with the object
}
