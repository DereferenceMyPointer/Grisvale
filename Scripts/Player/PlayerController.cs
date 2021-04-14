using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IHealth
{

    public Rigidbody2D rb;
    public Animator anim;
    public PlayerSettings settings;
    public Transform graphics;
    public float direction = 1f;
    public float interactDistance = 1f;
    public LayerMask interactable;
    public LayerMask damageable;
    public IInventory inventory;
    public Slider healthBar;
    public Slider powerBar;

    private IState activeState;
    public PMoveState moveState;
    public List<AudioSource> sounds;

    public float powerLevel;
    public float health;
    public bool immune;

    private bool isInstantiated = false;

    void Awake()
    {
        if (!isInstantiated)
        {
            isInstantiated = true;
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        health = settings.health;
        powerLevel = settings.power;
        moveState = new PMoveState(this);
        SetState(moveState);
    }

    private void Update()
    {
        activeState?.Perform();
        healthBar.value = health / settings.health;
        powerBar.value = powerLevel / settings.power;
    }

    public void SetState(PlayerIState state)
    {
        activeState?.End();
        activeState = state;
        activeState.Start();
    }

    public void Flip()
    {
        graphics.localScale = Mathf.Sign(direction) >= 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }

    public Vector2 Forward()
    {
        return transform.right * graphics.localScale.x;
    }

    public void PunchHit()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, (Vector3)Forward(), settings.attackRange, damageable);
        Debug.DrawLine(transform.position, transform.position + (Vector3)Forward() * settings.attackRange);
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider.TryGetComponent<IHealth>(out IHealth health))
            {
                health.Damage(settings.damage);
            }
        }
    }

    public void PlayAudioClip(string clipName)
    {
        foreach(AudioSource s in sounds)
        {
            if(s.name == clipName)
            {
                s.Play();
            }
        }
    }

    public bool Damage(float amount)
    {
        return false;
    }

    public float Heal(float amount)
    {
        return 0;
    }

}
