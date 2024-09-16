using UnityEngine;

public class RingToss : MonoBehaviour
{
    public Rigidbody ringRigidbody;    // Assign the Rigidbody of the ring
    public float throwForceMultiplier = 10f; // How strong the toss is
    public Transform playerCamera;     // Camera used for the throwing direction
    public bool isHeld = false;        // Is the ring being held?

    private Vector3 throwDirection;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = ringRigidbody.position;  // Save initial ring position for resetting
    }
    void Update()
    {
        if (isHeld)
        {
            // If holding, ring follows the camera's forward direction
            ringRigidbody.MovePosition(playerCamera.position + playerCamera.forward * 2f); // Adjust for distance from the player
        }
        if (Input.GetMouseButtonDown(0) && isHeld) // On mouse click/touch and ring is held
        {
            ThrowRing();
        }
    }
    public void PickUpRing()
    {
        // Activate the holding state
        isHeld = true;
        ringRigidbody.isKinematic = true;  // Disable physics until thrown
    }
    private void ThrowRing()
    {
        // When releasing, apply force and re-enable physics
        ringRigidbody.isKinematic = false;
        throwDirection = playerCamera.forward;  // Use camera forward direction for throw
        ringRigidbody.AddForce(throwDirection * throwForceMultiplier, ForceMode.Impulse);
        isHeld = false;
    }
    public void ResetRing()
    {
        ringRigidbody.position = startPosition; // Reset ring position
        ringRigidbody.velocity = Vector3.zero;  // Stop all movement
        ringRigidbody.angularVelocity = Vector3.zero; // Stop rotation
    }
}
