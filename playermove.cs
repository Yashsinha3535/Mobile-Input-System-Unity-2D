using UnityEngine;

public class playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    private float horizontalMove;
    private float PCHoriMove;
    private bool isGrounded;
    private bool isFacingLeft = true;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, whatIsGround);

        PCHoriMove = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("isJumping", isGrounded);

        
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            
            controlAnimations(PCHoriMove);
#elif UNITY_ANDROID
            controlAnimations(horizontalMove);       
#endif
        

    }


    void Move(float input)
    {
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);

        if (input > 0 && !isFacingLeft)
        {
            Flip();
        }
        else if (input < 0 && isFacingLeft)
        {
            Flip();
        }
        
        
    }


    void controlAnimations(float input)
    {
        if (input != 0)
        {
            _animator.SetInteger("Horizontal",1);
        }
        else if (input == 0)
        {
            _animator.SetInteger("Horizontal",0);
        }
    }


    private void Flip()
    {

        isFacingLeft = !isFacingLeft;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }

    public void mobileInputManage(float input)
    {
        horizontalMove = input;
    }

    public void MobilePlatJump()
    {
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }




    private void FixedUpdate()
    {
#if !UNITY_ANDROID
        Move(PCHoriMove);
#elif UNITY_ANDROID || UNITY_EDITOR
        Move(horizontalMove);
#endif
    }
}
    
    
    

