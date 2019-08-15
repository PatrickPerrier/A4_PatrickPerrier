using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    GameObject boomerangP;

    private Rigidbody2D myRigidBody;

    private Vector3 change;

    public Vector3 pDirection;

    private Animator animator;

    private GameObject mainCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        
        //Movement 
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MovePlayer();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
            pDirection = change;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        BoomerangShot();
    }
    void BoomerangShot()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(boomerangP, transform, false);
            Debug.Log("boomerang spaw");
        }
    }

    void MovePlayer()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
