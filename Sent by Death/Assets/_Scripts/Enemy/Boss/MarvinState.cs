using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvinState : MonoBehaviour
{
    public enum State
    {
        Atacando,
        Repouso
    }

    [SerializeField] AudioSource source;

    public State currentState;

    public float tempoEmRepouso = 3f;
    public float tempoDeAtaque = 3.3f;
    private float stateTimer;

    public Animator animator;
    BossLife life;
    public BoxCollider2D boxCollider;

    void Start()
    {
        currentState = State.Atacando;

        stateTimer = tempoDeAtaque;

        life = GetComponent<BossLife>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.Repouso:
                animator.SetBool("isAttacking", true);
                life.isInvencible = false;

                boxCollider.enabled = true;
                stateTimer -= Time.deltaTime;

                source.Play();

                if (stateTimer <= 0)
                {
                    currentState = State.Atacando;
                    stateTimer = tempoDeAtaque;
                }
                break;

            case State.Atacando:
                animator.SetBool("isAttacking", false);
                life.isInvencible = false;

                boxCollider.enabled = false;
                stateTimer -= Time.deltaTime;

                if (stateTimer <= 0)
                {
                    currentState = State.Repouso;
                    stateTimer = tempoEmRepouso;
                }
                break;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        source.Play();
    }
}
