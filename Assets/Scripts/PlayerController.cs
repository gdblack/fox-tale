using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    public float jumpForce;

    private bool _isGrounded;
    [SerializeField]
    private float _radius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private bool _canDoubleJump;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _radius, groundLayer);
        if (_isGrounded)
        {
            _canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
            else
            {
                if (_canDoubleJump)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                    _canDoubleJump = false;
                }
            }
                
        }
        if (rb2d.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (rb2d.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        _anim.SetFloat("moveSpeed", Mathf.Abs(rb2d.velocity.x));
        _anim.SetBool("isGrounded", _isGrounded);
    }
}