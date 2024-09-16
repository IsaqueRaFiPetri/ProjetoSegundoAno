using UnityEngine;

public class RingCollision : MonoBehaviour
{
    public int scoreValue = 1;  // Points for landing a ring
    private bool ringLanded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring") && !ringLanded)
        {
            // Detect when the ring hits the target
            Debug.Log("Ring Landed!");
            RingTossGameController.Instance.AddScore(scoreValue);  // Add to score (GameManager explained below)
            ringLanded = true; // Prevent scoring multiple times
        }
    }
}
