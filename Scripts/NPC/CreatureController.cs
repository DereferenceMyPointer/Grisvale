using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Transform graphics;
    public Animator anim;
    public IState currentState;
    public IdleState idle;

    [Header("Settings")]
    public float direction;
    public float moveSpeed;
    public float minTimeout;
    public float maxTimeout;

    private void Update()
    {
        
    }

    public void SetState(IState toState)
    {
        currentState.End();
        currentState = toState;
        currentState.Start();
    }

    public void Flip()
    {
        if(rb.velocity != Vector2.zero)
        {
            direction = rb.velocity.x;
        }
        graphics.localScale = Mathf.Sign(direction) >= 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }
}
