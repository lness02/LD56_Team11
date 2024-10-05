using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float countdownTime = 3f;
    public GameObject playerObject; // Reference to the player GameObject
    public Transform[] waypoints;   // Array of waypoints for the shadow to follow

    private int currentWaypointIndex = 0;
    private bool isChasingPlayer = false;
    private bool countdownActive = false;
    private float countdown = 0f;
    private PlayerController player; // Reference to the PlayerController script

    void Start()
    {
        // Get the PlayerController script from the player object
        player = playerObject.GetComponent<PlayerController>();

        // Start at the first waypoint
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (isChasingPlayer)
        {
            // Chase the player
            ChasePlayer();
        }
        else
        {
            // Follow the waypoint path
            MoveAlongWaypoints();
        }

        if (countdownActive)
        {
            // Countdown logic when player is detected in the shadow
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                GameOver();
            }
            else if (player.IsInSafeArea) // Check if player is in the safe area
            {
                // Cancel countdown and return to waypoint movement
                countdownActive = false;
                isChasingPlayer = false;
            }
        }
    }

    void MoveAlongWaypoints()
    {
        if (waypoints.Length == 0) return;

        // Move the shadow toward the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Check if the shadow has reached the current waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint, loop back if at the last waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        // Move the shadow toward the player's position
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, chaseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the player enters the shadow
        if (other.CompareTag("Player"))
        {
            // Start chasing the player and initiate countdown
            isChasingPlayer = true;
            countdownActive = true;
            countdown = countdownTime;
        }
    }

    void GameOver()
    {
        // Handle game over logic here
        Debug.Log("Game Over! The scientist caught you.");
    }
}
