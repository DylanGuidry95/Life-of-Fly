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
        rb.AddRelativeForce(mVelocity * Time.deltaTime, ForceMode.Acceleration);

        mVelocity = Vector3.zero;

        mVelocity.y = Input.GetAxis("Fly");
        rb.AddRelativeForce(mVelocity * Time.deltaTime, ForceMode.Acceleration);

        mDirection = Vector3.zero;

        mDirection.x = Input.GetAxis("LookVertical");
        mDirection.y = Input.GetAxis("LookHorizontal");
        rb.AddRelativeTorque(mDirection * Time.deltaTime, ForceMode.Acceleration);

        if(isFlying)
        {
            float zDif = -1 * transform.localEulerAngles.z;
            rb.AddRelativeTorque(0, 0, zDif * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    private Rigidbody rb;
    private Vector3 mVelocity;
    private Vector3 mDirection;
    private float mMaxSpeed;

    private bool isFlying;
}
