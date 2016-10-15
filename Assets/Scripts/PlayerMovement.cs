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
        //transform.Translate(mVelocity * Time.deltaTime, Space.Self);
        rb.AddRelativeForce(mVelocity, ForceMode.Acceleration);
        mVelocity = Vector3.zero;
        mVelocity.y = Input.GetAxis("Fly");
        //transform.Translate(0, mVelocity.y * Time.deltaTime, 0, Space.Self);
        rb.AddRelativeForce(mVelocity, ForceMode.Acceleration);

        mDirection = Vector3.zero;

        mDirection.x = Input.GetAxis("LookVertical");
        mDirection.y = Input.GetAxis("LookHorizontal");
        //transform.Rotate(mDirection, Space.Self);
        rb.AddTorque(mDirection);
    }

    private Rigidbody rb;
    private Vector3 mVelocity;
    private Vector3 mDirection;
    private float mMaxSpeed;

    private bool isFlying;
}
