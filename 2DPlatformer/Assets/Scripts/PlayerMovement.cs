using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public GameObject spawnPoint;
    // public BoxCollider2D body;

    private float m_HorizontalMove;
    public float runSpeed;
    private bool m_Jump;
    private bool m_Crouch;

    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsCrouching = Animator.StringToHash("isCrouching");

    // Update is called once per frame
    private void Update()
    {
        m_HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat(Speed, Mathf.Abs(m_HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            m_Jump = true;

            animator.SetBool(IsJumping, true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            m_Crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            m_Crouch = false;
        }

        if (gameObject.transform.position.y < -50)
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }

    public void OnLanding()
    {
        m_Jump = false;
        animator.SetBool(IsJumping, false);
    }

    public void OnCrouching(bool isCrouchingFromEvent)
    {
        animator.SetBool(IsCrouching, isCrouchingFromEvent);
    }

    private void FixedUpdate()
    {
        controller.Move(m_HorizontalMove * Time.fixedDeltaTime, m_Crouch, m_Jump);
        m_Jump = false;
    }
}