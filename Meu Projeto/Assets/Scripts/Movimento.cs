using UnityEngine;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{
    public float jumpForce;

    public float playerSpeed;

    public Rigidbody2D rb;

    private PlayerActions playerActions;

    private Vector2 moveDirections;

    [SerializeField]private Animator playerAnimation;

    // Sons
    [SerializeField] private AudioSource audioSourcePlayer;

    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxOnGround;

    void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerMovement.Jump.performed += Jump;
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    void FixedUpdate()
    {
        moveDirections = playerActions.PlayerMovement.Move.ReadValue<Vector2>();

        transform.Translate(moveDirections * playerSpeed * Time.deltaTime);

        playerAnimation.SetFloat("eixoX", moveDirections.x);
        playerAnimation.SetFloat("eixoY", moveDirections.y);

        if(moveDirections.x != 0)
        {

            playerAnimation.SetInteger("andando",1);

        }
        else
        {
            playerAnimation.SetInteger("andando",0);
        }


       
        
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSourcePlayer.PlayOneShot(sfxJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSourcePlayer.PlayOneShot(sfxOnGround);
        }
    }
}
