using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimationController : MonoBehaviour
{
    public GroundChecker groundChecker;
    public Animator animator;
    private bool isGrounded;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded != groundChecker.isGrounded())
        {
            if (!isGrounded)
            {
                animator.SetBool("landed", true);
            }
            isGrounded = groundChecker.isGrounded();
            animator.SetBool("isGrounded", isGrounded);
        }
        else {
            animator.SetBool("landed", false);
        }
        //animator.SetFloat("move", Mathf.Abs(Input.GetAxis("Horizontal"))+ Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            Debug.Log("a");
            animator.SetFloat("move", 10f);
        }
        else {
            Debug.Log("b");
            animator.SetFloat("move", 0.0f);
        }
    }
}
