using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public Hero Hero;
    public string Id;


    protected enum State
    {
        idle, move, attack, hurt, die
    }

    //public event VoidFunc onDie;

    private Transform target;
    public Animator animator;
    protected AudioSource audioSource;
    float x;
    State state = State.idle;

    [Header("ID Info")]
    public string ID;

    [Header("HP")]
    public Image HPImage;
    public EntityHitBox HitBox;
    public double maxHP = 5;
    public double HP = 5;

    [Header("Hurt detail")]
    public float HurtTime = 0.4f;
    public AudioClip hurtClip;

    [Header("Attack")]
    public List<EntityAttack> Attacks;

    [Header("Other enemy properties")]
    public float speed = 1;
    public float area = 1;
    public float cd = 1f;

    bool isEnemy = true;

    protected State CurrentState
    {
        get
        {
            return state;
        }

        set
        {
            reactOnStateChange(value);
            state = value;
        }
    }

    void reactOnStateChange(State newState)
    {
        switch (newState)
        {
            case State.idle:
                animator.Play("Idle");
                break;

            case State.move:
                animator.Play("Walking");
                break;

            case State.attack:
                break;

            case State.hurt:
                audioSource.clip = hurtClip;
                audioSource.Play();
                animator.Play("Hurt");
                break;

            case State.die:
                audioSource.clip = hurtClip;
                audioSource.Play();
                animator.Play("Dying");
                StartCoroutine(DieCoroutine());
                break;
        }

    }

    public Vector3 getTargetPosition()
    {
        var targets = GameObject.FindGameObjectsWithTag("Enemy");


        var distance = float.MaxValue;

        foreach (var t in targets)
        {
            var td = Vector2.Distance(transform.position, t.transform.position);
            if (td < distance)
            {
                distance = td;
                target = t.transform;
                isEnemy = true;
            }
        }

        if(targets.Length == 0)
        {
            target = Hero.transform;
            isEnemy = false;
        }

        return target.position;
    }

    void Start()
    {
        //animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        x = transform.localScale.x;
        HPImage.fillAmount = (float)(HP / maxHP);
    }

    bool firstUpdate = true;
    public virtual void Update()
    {
        if (firstUpdate)
        {
            HitBox.hurt += Hurt;
            firstUpdate = false;
        }

        if (cd > 0) cd -= Time.deltaTime;
        else cd = 0;
        if (CurrentState != State.idle && CurrentState != State.move) return;

        if (transform.position.x < getTargetPosition().x)
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-x, transform.localScale.y, transform.localScale.z);
        }


        if (Vector2.Distance(transform.position, getTargetPosition()) > area)
        {
            transform.position = Vector2.MoveTowards(transform.position, getTargetPosition(), speed * Time.deltaTime);
            CurrentState = State.move;
        }
        else
        {
            if (cd <= 0 && isEnemy) StartCoroutine(AttackCoroutine());
            else CurrentState = State.idle;
        }

    }


    public virtual void Hurt(EnemySlashBox slash)
    {
        HP -= slash.Damage;
        HPImage.fillAmount = (float)(HP / maxHP);
        if (HP > 0)
        {
            StartCoroutine(HurtCoroutine());
        }
        else
        {
            CurrentState = State.die;
            enabled = false;
        }
    }

    public virtual IEnumerator HurtCoroutine()
    {
        CurrentState = State.hurt;
        yield return new WaitForSeconds(HurtTime);
        if (CurrentState != State.die) CurrentState = State.idle;
    }

    public virtual IEnumerator AttackCoroutine()
    {
        CurrentState = State.attack;
        var attack = ProbabilityMaster.EntityAttackFrom(Attacks);
        attack.Attack();
        yield return new WaitForSeconds(attack.animationDuration);
        cd += attack.afterCD;
        if (CurrentState != State.die) CurrentState = State.idle;
    }

    public virtual IEnumerator DieCoroutine()
    {
        Destroy(HitBox.gameObject);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
