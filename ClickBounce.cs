using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBounce : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()  // This function is called once per frame
    {
        if (Input.GetKeyDown(KeyCode.B)) // Check if the B key is pressed
        {
            animator.Play("Bounce", -1, 0f);  // Play the bounce animation from the start
        }
    }
}
