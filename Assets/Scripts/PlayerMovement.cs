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
        rb.AddRelativeForce(mVelocity * speed, ForceMode.Acceleration);

        mVelocity = Vector3.zero;

        mVelocity.y = Input.GetAxis("Fly");
        rb.AddRelativeForce(mVelocity * speed, ForceMode.Acceleration);

        mDirection = Vector3.zero;

        mDirection.x = Input.GetAxis("LookVertical");
        mDirection.y = Input.GetAxis("LookHorizontal");
        mDirection.z = Input.GetButton("Fire3") ? -Input.GetAxis("Horizontal") : 0;
        rb.AddRelativeTorque(mDirection * speed, ForceMode.Acceleration);
    }

    void OnTriggerStay(Collider other)
    {
        float speed = mSpeed * Time.deltaTime;

        RaycastHit hit;

        isFlying = false;

        Vector3 directionToSurface = other.transform.position - transform.position;
        directionToSurface.Normalize();

        Physics.Raycast(transform.position, directionToSurface, out hit);

        directionToSurface = hit.point - transform.position;
        directionToSurface.Normalize();

        speed *= 0.75f;
        rb.AddRelativeForce(directionToSurface * speed, ForceMode.Acceleration);

        Debug.DrawLine(transform.position, transform.position + directionToSurface, Color.red);
        Debug.Log(hit.point);
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

    private bool isFlying = true;
}
