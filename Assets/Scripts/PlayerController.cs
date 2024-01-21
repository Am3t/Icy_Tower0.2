using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;

    //Жизни
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;
    [SerializeField] int speed;
    [SerializeField] int jumpForce;
    [SerializeField] Transform groundCheck;
    

    //ДВижение так же
    Animator animator;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    bool isGrounded;


    private Rigidbody2D _rigidbody;
    private bool _isOnPlatform => _rigidbody.IsTouching(_platform);



    private void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    /*public void Jump()
    {
        if (_isOnPlatform == true)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.transform.parent != null)
        {
            if (collisionObject.transform.parent.TryGetComponent(out Platform platform))
                platform.StopMovement();
        }

        if (collisionObject.CompareTag("PlatformWall"))
            Dead?.Invoke();
            //health = health - 1;
        else if(collisionObject.CompareTag("Platform"))
        {
            collisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }



    //Движение
    private void FixedUpdate()
    {
        //Здоровье игрока
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health)){
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;
            } 
        }



        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (isGrounded)
                animator.Play("Player_Run");

            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (isGrounded)
                animator.Play("Player_Run");

            sprite.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (isGrounded)
                animator.Play("Player_Idle");
        }

        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.Play("Player_Jump");
        }
    }
}