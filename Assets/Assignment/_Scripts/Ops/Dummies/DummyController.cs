using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayHitAnimation()
    {
        animator.CrossFadeInFixedTime("Hit", 0.01f);
    }

    public void PlayDeadAnimation()
    {
        animator.CrossFadeInFixedTime("dead", 0.01f);
    }

    public void PlayJumpAnimation()
    {
        animator.CrossFadeInFixedTime("jump", 0.01f);
    }
}
