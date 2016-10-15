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
        float speed = mSpeed * Time.deltaTime;

        mVelocity = Vector3.zero;

        mVelocity.z = Input.GetAxis("Vertical");
        mVelocity.x = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(mVelocity * speed * mSpeedMod, ForceMode.Acceleration);

        mVelocity = Vector3.zero;

        mVelocity.y = Input.GetAxis("Fly");
        rb.AddRelativeForce(mVelocity * speed * mFlyMod, ForceMode.Acceleration);

        mDirection = Vector3.zero;

        mDirection.x = Input.GetAxis("LookVertical");
        mDirection.y = Input.GetAxis("LookHorizontal");
        mDirection.z = Input.GetButton("Fire3") ? -Input.GetAxis("Horizontal") : 0;
        rb.AddRelativeTorque(mDirection * speed * mRotationMod, ForceMode.Acceleration);
    }

    void OnTriggerStay(Collider other)
    {
        float speed = mSpeed * Time.deltaTime;

        isFlying = false;

        Vector3 down = transform.position - (transform.position + transform.up);
        down.Normalize();

        speed *= mFlyMod * 0.25f;

        rb.AddForce(down * speed, ForceMode.Acceleration);

        Debug.DrawRay(transform.position + transform.up, down * 10, Color.red);
    }

    void OnTriggerExit(Collider other)
    {
        isFlying = true;
    }

    private Rigidbody rb;
    private Vector3 mVelocity;
    private Vector3 mDirection;

    [SerializeField]
    private float mSpeed = 1;
    [SerializeField]
    private float mSpeedMod, mRotationMod, mFlyMod;

    private bool isFlying = true;
}
