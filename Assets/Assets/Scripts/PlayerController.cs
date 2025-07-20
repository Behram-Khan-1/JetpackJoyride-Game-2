using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 5f;
    [SerializeField] Rigidbody2D rb;
    private Animator animator;
    private ParticleSystem jetpackParticles;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jetpackParticles = this.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsFlying", false);
            jetpackParticles.Stop();
        }
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("IsGrounded", false);
            animator.SetBool("IsFlying", true);
            animator.SetBool("IsFalling", false);
            if (!jetpackParticles.isPlaying)
            jetpackParticles.Play();
        }
        else
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsFlying", false);
            jetpackParticles.Stop();
        }
    }

}