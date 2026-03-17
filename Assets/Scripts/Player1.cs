using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D PlayerRb;

    public float Speed;
    private float MoveInput;
    private float MoveBy;

    public GameObject GroundCheck;
    private bool IsGrounded;
    public float JumpForce;
    private bool CanJump = true;
    private bool CanStop;

    private bool CanDash = true;
    private bool CanDashAgain;
    private bool IsDashing;
    public float DashSpeed;
    public float DashCooldown;
    public float DashTime;

    private bool CanMove = true;
    private bool FirstCol = true;

    private AudioSource AudioManager;
    public AudioClip AttackSound;
    public AudioClip LandSound;
    public AudioClip JumpSound;
    public AudioClip DashSound;
    public AudioSource Footsteps;

    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayerRb = GetComponent<Rigidbody2D>();
        AudioManager = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(CanMove)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                CanJump = true;
            }

            Turn();
            Dash();
            Attack();
        }
    }

    void FixedUpdate()
    {
        if(CanMove)
        {
            Run();
            Jump();

            if (IsDashing == true)
            {
                PlayerRb.linearVelocity = new Vector2(transform.localScale.x * DashSpeed, PlayerRb.linearVelocity.y);
            }

            if (Thrust == true)
            {
                PlayerRb.linearVelocity = new Vector2(transform.localScale.x * AttackSpeed, PlayerRb.linearVelocity.y);
            }
        }
    }

    void Run()
    {
        if(IsAttacking == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveInput = 1f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                MoveInput = -1f;
            }
            else
            {
                MoveInput = 0f;
            }

            MoveBy = MoveInput * Speed * Time.deltaTime;
            PlayerRb.linearVelocity = new Vector2(MoveBy, PlayerRb.linearVelocity.y);
            if (MoveInput != 0)
            {
                Anim.SetBool("IsRunning", true);
            }
            else
            {
                Anim.SetBool("IsRunning", false);
                PlayerRb.linearVelocity = new Vector2(0f, PlayerRb.linearVelocity.y);
            }
        }

        if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            Footsteps.enabled = true;
        }
        else
        {
            Footsteps.enabled = false;
        }
    }

    void Jump()
    {   
        Anim.SetBool("IsJumping", CanStop);

        if (Input.GetKey(KeyCode.W) && IsGrounded && CanJump && !IsAttacking && !IsDashing)
        {
            AudioManager.PlayOneShot(JumpSound);
            PlayerRb.linearVelocity = new Vector2(PlayerRb.linearVelocity.x, JumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D GroundCheck)
    {
        if (GroundCheck.gameObject.tag == "Ground")
        {
            if (FirstCol)
            {
                FirstCol = false;
            }
            else
            {
                AudioManager.PlayOneShot(LandSound);
            }
        }
    }

    void OnTriggerStay2D(Collider2D GroundCheck)
    {
        if (GroundCheck.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            if(CanStop)
            {
                CanStop = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D GroundCheck)
    {
        if (GroundCheck.gameObject.tag == "Ground")
        {
            IsGrounded = false;
            CanJump = false;
            CanStop = true;
        }
    }

    void Turn()
    {
        if (MoveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (MoveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
    }

    void Dash()
    {
        //Physics2D.IgnoreLayerCollision(7, 6, IsDashing);

        if (Input.GetKey(KeyCode.S) && IsGrounded && !IsDashing && CanDash && CanDashAgain && !IsAttacking)
        {
            StartCoroutine(StartDashing());
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            CanDashAgain = true;
        }
    }

    private IEnumerator StartDashing()
    {
        gameObject.tag = "Untagged";
        AudioManager.PlayOneShot(DashSound);
        CanDash = false;
        CanDashAgain = false;
        IsDashing = true;
        Anim.SetBool("IsDashing", true);
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        Anim.SetBool("IsDashing", false);
        gameObject.tag = "Player";
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;
    }

    private bool IsAttacking;
    private bool NextAttack = true;
    public float AttackTime;
    public float RecoveryTime;
    public GameObject AttackHitbox;
    public float AttackSpeed;
    private bool Thrust;
    private bool CanAttack = true;

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space) && !IsAttacking && !IsDashing && NextAttack && IsGrounded && CanAttack)
        {
            StartCoroutine(StartAttack());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            NextAttack = true;
        }
    }

    private IEnumerator StartAttack()
    {
        AudioManager.PlayOneShot(AttackSound);
        IsAttacking = true;
        NextAttack = false;
        Thrust = true;
        Anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(AttackTime);
        Thrust = false;
        AttackHitbox.SetActive(true);
        yield return new WaitForSeconds(RecoveryTime);
        AttackHitbox.SetActive(false);
        Anim.SetBool("IsAttacking", false);
        IsAttacking = false;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.3f);
        CanAttack = true;
    }

    public void GetHit()
    {
        Anim.SetTrigger("Hit");
    }

    public void EndGame(bool HasWon)
    {
        Footsteps.enabled = false;
        CanMove = false;
        if(!HasWon)
        {
            Anim.SetBool("Death", true);
        }
        else
        {
            Anim.SetBool("IsRunning", false);
            Anim.SetBool("IsAttacking", false);
            Anim.SetBool("IsJumping", false);
            Anim.SetBool("IsDashing", false);
        }
    }
}
