using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.05f)
        {
            currentPoint++;
        }
        if (currentPoint >= points.Length)
        {
            currentPoint = 0;
        }
        if (transform.position.x < points[currentPoint].position.x)
        {
            spriteRenderer.flipX = true;
        } else if (transform.position.x > points[currentPoint].position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}