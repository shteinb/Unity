using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnKeyPress : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Rotate"); // 'Rotate' is a trigger parameter in the Animator
        }
    }
}
