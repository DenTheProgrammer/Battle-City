using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float bulletSpeed = 0.5f;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject bulletPrefab;

    private Rigidbody2D rb;
    private Vector2 currentDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Go(Vector2.right);
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            Go(Vector2.left);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Go(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Go(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
         
    }

    private void Turn(Vector2 direction)
    {
        if (direction == Vector2.up)
            rb.SetRotation(0);
        else if (direction == Vector2.left)
            rb.SetRotation(90);
        else if (direction == Vector2.down)
            rb.SetRotation(180);
        else if (direction == Vector2.right)
            rb.SetRotation(270);

        currentDirection = direction;
    }

    private void Thrust()
    {
        rb.MovePosition(rb.position + currentDirection * speed);
    }

    private void Go(Vector2 direction)
    {
        if (direction != currentDirection)
            Turn(direction);
        Thrust();
    }

    private void Shoot()
    {
        Debug.Log("Pew!");
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.GetRelativeVector(Vector2.up) * bulletSpeed, ForceMode2D.Impulse);
    }
}
