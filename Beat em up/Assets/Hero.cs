using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spriter2UnityDX;

public enum HeroState
{
    idle, move, attack, hurt, die, slide
}

public class Hero : MonoBehaviour
{
    public event VoidFunc onDie;

    public string ID;

    [Header("Hero Control Element")]
    [SerializeField]
    Joystick joystick;

    [SerializeField]
    public HeroHitBox HitBox;

    [SerializeField]
    Image HPImage;

    [SerializeField]
    AudioSource step;

    public AudioClip hurtClip;

    protected AudioSource audioSource;


    [Header("Hero Property")]
    public double maxHP;
    public double HP;
    public float Speed = 3;
    public float speedMult = 1;

    public float DamageMult = 1;


    public List<PlayerMove> moves;

    Rigidbody2D rb;
    SpriteRenderer sr;
    EntityRenderer er;
    Animator animator;

    public float dieTime = 0.5f;

    bool isAttacking = false;
    HeroState state = HeroState.idle;

    public HeroState CurrentState
    {
        get
        {
            return state;
        }
        set
        {
            ReactOnStateChange(value);
            state = value;
        }
    }

    public bool IsDie
    {
        get
        {
            return CurrentState == HeroState.die;
        }
    }

    public Dictionary<string, bool> options = new Dictionary<string, bool>();

    public bool optionCheck(string option)
    {
        if(options.ContainsKey(option))
        {
            return options[option];
        } else
        {
            return false;
        }
    }

    public bool IsInverted { get; private set; } = false;

    public void SetIsAttacking(bool value)
    {
        isAttacking = value;
    }

    public void PlayAnimation(string clipName)
    {
        animator.Play(clipName);
    }

    public void SetHitBoxEnabled(bool value)
    {
        HitBox.GetComponent<BoxCollider2D>().enabled = value;
    }

    public void AddForce(Vector2 value)
    {
        rb.AddForce(value);
    }

    public void SetHPFill(float value)
    {
        HPImage.fillAmount = value;
    }

    void ReactOnStateChange(HeroState newState)
    {
        switch (newState)
        {
            case HeroState.idle:
                PlayAnimation("Idle");
                break;
            case HeroState.move:
                PlayAnimation("Walking");
                break;
            case HeroState.hurt:
                audioSource.clip = hurtClip;
                audioSource.Play();
                PlayAnimation("Hurt");
                break;
            case HeroState.die:
                PlayAnimation("Dying");
                enabled = false;
                StartCoroutine(Helper.Wait(dieTime + 0.25f, () => { onDie(); }));
                break;
            case HeroState.slide:
                PlayAnimation("Sliding");
                break;
        }

    }

    public bool CanAttack()
    {
        return !IsDie && !isAttacking;
    }

    public bool CanMove()
    {
        return (CurrentState == HeroState.idle || CurrentState == HeroState.move) && !isAttacking;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        er = GetComponent<EntityRenderer>();
        animator = GetComponent<Animator>();
        SetHPFill((float)(HP / maxHP));
        HitBox.hurt += Hurt;
        audioSource = GetComponent<AudioSource>();
    }

    

    void Update()
    {
        //if(er != null)er.Color = Color.red;
        //if (sr != null) sr.color = Color.red;
        if (!CanMove()) return;

        //if (er != null) er.Color = Color.green;
        //if (sr != null) sr.color = Color.green;


        Vector2 velocity = new Vector2(joystick.Horizontal, joystick.Vertical);
        
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            PlayAnimation("Idle");
            step.Stop();
        }
        else
        {
            PlayAnimation("Walking");
            if(!step.isPlaying)
            {
                step.Play();
            }
        }
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Speed * speedMult * Time.deltaTime; ;

        if (joystick.Horizontal < 0) IsInverted = true;
        else if (joystick.Horizontal > 0) IsInverted = false;
        var x = Mathf.Abs(transform.localScale.x);



        transform.localScale = new Vector3(IsInverted ? -x : x, transform.localScale.y, transform.localScale.z);

    }

    void Hurt(double damage)
    {
        HP-= damage;
        SetHPFill((float)(HP / maxHP));
        if (HP > 0)
        {
            StartCoroutine(HurtCoroutine());
        }
        else
        {
            CurrentState = HeroState.die;
            rb.velocity = new Vector2();
            enabled = false;
        }
    }

    public void Heal(float value)
    {
        HP += value;
        HP = Mathf.Min((float)HP, (float)maxHP);
        SetHPFill((float)(HP / maxHP));
    }
         
    IEnumerator HurtCoroutine()
    {
        CurrentState = HeroState.hurt;
        yield return new WaitForSeconds(0.4f);
        if (CurrentState != HeroState.die) CurrentState = HeroState.idle;
    }
    
}
