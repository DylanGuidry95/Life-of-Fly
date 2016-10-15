using UnityEngine;
using System.Collections;

public class Boids : MonoBehaviour
{
    public Vector3 Position;
    public Vector3 Velocity;
    public float MaxVelocity;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.up = Velocity;
	    transform.localPosition = Position; 
	}
}
