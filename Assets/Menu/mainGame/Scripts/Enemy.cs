using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

    public Transform groundCheck;

    bool isFacingRight = true;

    RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, new Vector2(0,-1), 1f, groundLayers);
    }

    private void FixedUpdate()
    {
        if (hit.collider != false)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

        }
        else
        {
            isFacingRight = !isFacingRight;
            //transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);

            //transform.localPosition = new Vector3(-transform.localPosition.x, 1f, 1f);
        }
    }
}
