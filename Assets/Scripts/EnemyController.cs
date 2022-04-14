using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;
    public float moveTime, waitTime;
    private float moveCount, waitCount;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                spriteRenderer.flipX = true;
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                spriteRenderer.flipX = false;
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, waitTime * 0.75f);
            }
            anim.SetBool("isMoving", false);
        }
    }
}
