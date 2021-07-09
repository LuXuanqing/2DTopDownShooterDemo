using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterBase : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void PlayIdleAnimation(Vector3 direction)
    {

    }
    public void PlayWalkingAnimation(Vector3 direction) { }
}
