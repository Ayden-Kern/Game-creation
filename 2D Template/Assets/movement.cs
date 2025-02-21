using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class movementScript
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    public float speed = 10, jumpheight = 15, MaxSpeed = 30;
    public KeyCode jump = KeyCode.W;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [Header("Raycast")]

    [SerializeField] float dist; //raycast range
    [SerializeField] float downRange = -0.75f; //offset
    [SerializeField] float health, maxHealth = 1;

    bool ground;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            _rb.AddForce(Vector2.left * speed * Time.deltaTime);
            _animator.SetBool("Is_moving", true);
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(right))
        {
            _rb.AddForce(Vector2.right * speed * Time.deltaTime);
            _animator.SetBool("Is_moving", true);
            _spriteRenderer.flipX = false;
        }
        else
        {
            _animator.SetBool("Is_moving", false);
        }
        if (Input.GetKey(up))
        {
            _rb.linearVelocity = Vector2.up * speed;
        }
        if (Input.GetKeyDown(down))
        {
            _rb.linearVelocity = Vector2.down * speed;
        }
        if (_rb.linearVelocity.x > MaxSpeed)
            _rb.linearVelocity = new Vector2(MaxSpeed, _rb.linearVelocity.y);
        if (_rb.linearVelocity.x > MaxSpeed)
            _rb.linearVelocity = new Vector2(-MaxSpeed, _rb.linearVelocity.y);
        _animator.SetFloat("speed", Mathf.Abs(_rb.linearVelocity.x));


        //orgin position * in the down dir downRange, direction, range
        bool ray = Physics2D.Raycast(transform.position + (Vector3.down * downRange), Vector2.down, dist);
        //bool ray = Physics2D.BoxCast(transform.position *())

        //print(ray);

        if (ray && Input.GetKeyDown(jump))
        {
            _rb.AddForce(Vector2.up * jumpheight);
            _animator.SetTrigger("Jumped");
            _animator.SetBool("Is_moving", false);
        }
        if (Input.GetKeyUp(jump))
        {
            _rb.linearVelocity = new(_rb.linearVelocity.x, _rb.linearVelocity.y / 2);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + (Vector3.down * downRange), transform.position + Vector3.down * dist);
    }
}
