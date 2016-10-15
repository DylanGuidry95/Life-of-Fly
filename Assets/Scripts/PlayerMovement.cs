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
        rb.AddRelativeForce(mVelocity * mSpeed * Time.deltaTime, ForceMode.Acceleration);

        mVelocity = Vector3.zero;

        mVelocity.y = Input.GetAxis("Fly");
        rb.AddRelativeForce(mVelocity * mSpeed * Time.deltaTime, ForceMode.Acceleration);

        mDirection = Vector3.zero;

        mDirection.x = Input.GetAxis("LookVertical");
        mDirection.y = Input.GetAxis("LookHorizontal");
        rb.AddRelativeTorque(mDirection * mSpeed * Time.deltaTime, ForceMode.Acceleration);
        
        if (isFlying)
        {
            Vector3 zeroZ = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, zeroZ, 1);
        }
    }



    private Rigidbody rb;
    private Vector3 mVelocity;
    private Vector3 mDirection;

    [SerializeField]
    private float mSpeed = 1;

    private bool isFlying = false;
}
