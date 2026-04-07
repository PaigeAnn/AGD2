using UnityEngine;
using System.Collections;

public class FountainTeleport : MonoBehaviour
{
    public Transform destination; // Assign in Inspector
    public float cooldown = 0.5f;

    private bool canTeleport = true;

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

        // Move player to destination
        player.position = destination.position;

        yield return new WaitForSeconds(cooldown);

        canTeleport = true;
    }
}