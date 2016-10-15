using UnityEngine;
using System.Collections;


public class BoidBehavior : MonoBehaviour
{
    [SerializeField]
    private System.Collections.Generic.List<Boids> BoidSystem;
    [SerializeField]
    private int NumBoids;
    [SerializeField]
    private float DistanceFromNeighbor;
    [SerializeField]
    private float cohMod = 1;
    [SerializeField]
    private float sepMod = 0;

	// Use this for initialization
	void Start ()
    {
        BoidSystem = new System.Collections.Generic.List<Boids>();
	    for(int i = 0; i < NumBoids; i++)
        {
            Boids b = Instantiate(Resources.Load("Boid", typeof(Boids))) as Boids;
            b.transform.parent = transform;
            b.transform.localScale = new Vector3(1,1,1);
            b.Position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            BoidSystem.Add(b);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cohesion, seperation, seek;
        foreach(Boids b in BoidSystem)
        {
            cohesion = Cohesion(b) * cohMod;
            seperation = Seperation(b) * sepMod;
            seek = Seek(b);
            b.Velocity += cohesion + seperation;

            b.Position += b.Velocity  ;
        }
	}

    Vector3 Cohesion(Boids b)
    {
        Vector3 force = Vector3.zero;
        foreach (Boids boid in BoidSystem)
        {
            if (b != boid)
            {
                force = force + b.Position;
            }
        }
        force = force / (NumBoids - 1);

        return (force - b.Position) / 8;
    }

    Vector3 Seperation(Boids b)
    {
        Vector3 force = Vector3.zero;
        foreach(Boids boid in BoidSystem)
        {
            if(b != boid)
            {
                if(Vector3.Magnitude(b.Position - boid.Position) < DistanceFromNeighbor)
                    force = force - (b.Position - boid.Position);
            }
        }
        return force;
    }

    Vector3 Seek(Boids b)
    {
        Vector3 boid = Vector3.zero;
        return boid;
    }

    Vector3 Wall(Boids b)
    {
        Vector3 v = Vector3.zero;

        if (b.Position.x < (gameObject.transform.position.x - .1f))
        {
            v.x = .1f;
        }
        else if (b.Position.x > (gameObject.transform.position.x + .1f))
        {
            v.x = -.1f;
        }


        if (b.Position.y < (gameObject.transform.position.y - .1f))
        {
            v.y = .1f;
        }
        else if (b.Position.y > (gameObject.transform.position.y + .1f))
        {
            v.y = -.1f;
        }


        if (b.Position.z < (gameObject.transform.position.z - .1f))
        {
            v.z = .1f;
        }
        else if (b.Position.z > (gameObject.transform.position.x + .1f))
        {
            v.z = -.1f;
        }

        return v;
    }
}
