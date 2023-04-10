using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float jumpVelocity = 0f;
    public int deathFallTimer = 0;
    public int deathLimit = 200;

    public GameManager gm;
    Rigidbody2D rb;
    Collider2D collider2d;

    public bool isGrounded;
    public bool isGroundedSecond;
    public LayerMask whatIsGround;

    [SerializeField] private Animator player = null;
    [SerializeField] private Animator heart = null;
    //[SerializeField] private string = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();
        }
    }

    void Start()
    {
        //gm = gameObject.AddComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        PlayerPrefs.SetInt("dj", 0);
    }

    void Update()
    {
        isGroundedSecond = Physics2D.IsTouchingLayers(collider2d, whatIsGround);
        if (isGrounded != isGroundedSecond) {
            if (isGroundedSecond) player.Play("LuigiRun", 0, 0f);
            else player.Play("LuigiJump", 0, 0f);
        }

        isGrounded = isGroundedSecond;
        rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);

        if (isGrounded) {
            deathFallTimer = 0;
            if (Input.GetKeyDown(KeyCode.Space))
                rb.velocity = Vector2.up * jumpVelocity;
        }
        else {
            deathFallTimer++;
            if (deathFallTimer > deathLimit) gm.EndGame();
            if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("dj") == 1) {
                rb.velocity = Vector2.up * jumpVelocity;
                PlayerPrefs.SetInt("dj", 0);
            }
        }
        
    }

    public void DeathAnim() {
        player.Play("LuigiJump", 0, 0f);
        heart.Play("Heart", 0, 0f);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
