using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;
    public Transform farBackground, middleBackground;
    public float minHeight, maxHeight;

    private float lastXPos, lastYPos;
    private Vector2 lastPos;
    public bool stopFollow;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        //lastYPos = transform.position.y;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            // Paralax on x axis
            //float amountToMoveX = transform.position.x - lastXPos;
            //farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
            //middleBackground.position += new Vector3(amountToMoveX * 0.5f, 0f, 0f);
            //lastXPos = transform.position.x;

            //// Paralax on y axis
            //float amountToMoveY = transform.position.y - lastYPos;
            //farBackground.position += new Vector3(0f, amountToMoveY, 0f);
            //middleBackground.position += new Vector3(0f, amountToMoveY * 0.5f, 0f);
            //lastYPos = transform.position.y;

            // New consolidated code
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
            farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;

            lastPos = transform.position;
        }
    }
}
