using UnityEngine;
using System.Collections;

public class FountainTeleport : MonoBehaviour
{
    public Transform destination; // Assign in Inspector
    public float cooldown = 1f;

    private bool canTeleport = true;

    public Collider2D teleportCollider; // Assign in Inspector

    // Start is called before the first frame update
    void Start()
    {
        // You usually don't need anything here for teleporting

    }

    // Update is called once per frame
    void Update()
    {
        // Not needed for this script, but included for structure
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            StartCoroutine(Teleport(other.transform));
        }
    }

    IEnumerator Teleport(Transform player)
    {
        canTeleport = false;

        teleportCollider.enabled = false; // Disable collider to prevent immediate re-teleportation
        // Move player to destination
        player.position = destination.position;

        yield return new WaitForSeconds(cooldown);
        teleportCollider.enabled = true; // Re-enable collider after cooldown

        canTeleport = true;
    }
}