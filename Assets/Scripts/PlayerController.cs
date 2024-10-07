using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isInSafeArea = false;

    // Property to access isInSafeArea status
    public bool IsInSafeArea
    {
        get { return isInSafeArea; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Player movement input
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        

        // Apply movement 
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Apply movement to the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Camera follows the player
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }

    // Detect when the player enters or exits the safe area
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SafeArea"))
        {
            isInSafeArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SafeArea"))
        {
            isInSafeArea = false;
        }
    }
}
