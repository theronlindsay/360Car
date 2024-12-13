using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
