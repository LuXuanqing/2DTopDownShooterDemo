using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 4f;
    private PlayerCharacterBase playerCharacterBase;
    private Animator animator;


    private void Awake()
    {
        playerCharacterBase = gameObject.GetComponent<PlayerCharacterBase>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        bool isIdle = moveX == 0 && moveY == 0;
        animator.SetBool("isIdle", isIdle);
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);

        if (!isIdle)
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
        }

    }
}
