using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotsquidwardAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsRotating", false); // Ensure rotation doesn't start automatically
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bool isCurrentlyRotating = animator.GetBool("IsRotating");
            Debug.Log("R key pressed. Current IsRotating value: " + isCurrentlyRotating);

            animator.SetBool("IsRotating", !isCurrentlyRotating);
            Debug.Log("New IsRotating value: " + animator.GetBool("IsRotating"));
        }
    }

}
