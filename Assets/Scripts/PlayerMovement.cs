using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Update ()
    {
        mVelocity = Vector3.zero;

        mVelocity.z = Input.GetAxis("Vertical");
        mVelocity.x = Input.GetAxis("Horizontal");

        transform.Translate(mVelocity, Space.Self);
    }

    private Rigidbody rb;
    private Vector3 mVelocity;
    private float mMaxSpeed;
}
