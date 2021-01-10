using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public GameObject spawnPoint;
    // public BoxCollider2D body;

    private float _horizontalMove;
    public float runSpeed;
    private bool _jump;
    private bool _crouch;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsCrouching = Animator.StringToHash("IsCrouching");

    // Update is called once per frame
    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat(Speed, Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;

            animator.SetBool(IsJumping, true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            _crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            _crouch = false;
        }

        if (gameObject.transform.position.y < -50)
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }

    public void OnLanding()
    {
        _jump = false;
        animator.SetBool(IsJumping, false);
    }

    public void OnCrouching(bool isCrouchingFromEvent)
    {
        animator.SetBool(IsCrouching, isCrouchingFromEvent);
    }

    private void FixedUpdate()
    {
        controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }
}