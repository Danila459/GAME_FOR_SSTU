using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public LayerMask playerMask;
    public GameObject Sword,pos_sword;
    public bool canMoveInAir = true;


    float fireRate = 0;
    float nextfire = 0;
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private float moveInput;
    private bool facingRight;

    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float circleRadius;
    [SerializeField] private LayerMask whatIsGround;

    private Animator anim;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, whatIsGround);
        CharacterJump();

        if(fireRate == 0)
        {

          if(Input.GetKeyDown(KeyCode.Space))
          {
            Shooting();
          }
          else
          {
            if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire)
            {
              nextfire = Time.time + nextfire;
              Shooting();
            }
          }
        }
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0){
            died();
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      if(coll.gameObject.tag == "Batas_Mati")
      {
        died();
      }
    }

    void Die(){
        Debug.Log("Game Over");
		SceneManager.LoadScene("Menu");
    }

    void died()
    {
      SceneManager.LoadScene("GameOver");
    }


    private void FixedUpdate()
    {
        CharacterMovement();
        CharacterAnimation();
    }
    public float Scale_karak;
     void Shooting(){
           if (Scale_karak == 1f){
            GetComponent<Rigidbody2D>().velocity = new Vector2(8f, GetComponent<Rigidbody2D>().velocity.y);
        }
        else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, GetComponent<Rigidbody2D>().velocity.y);
        }
        Instantiate(Sword, pos_sword.transform.position, pos_sword.transform.rotation);
    }

    private void CharacterMovement()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0 && facingRight == false)
        {

            Flip();
        }
        else if (moveInput < 0 && facingRight == true)
        {

            Flip();
        }
        rigidBody.velocity = new Vector2(speed * moveInput, rigidBody.velocity.y);
    }

    void CharacterJump()
    {

        if (isGrounded == true &&  Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("isJump");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    void CharacterAnimation()
    {
        if (moveInput != 0 && isGrounded == true)
        {
            anim.SetBool("isRun", true);

        }
        else if (moveInput == 0 && isGrounded == true)
        {
            anim.SetBool("isRun", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
