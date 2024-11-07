using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;

    public bool isBusy {get; private set;}
    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float dashDuration;
    private float defaultMoveSpeed;
    private float defaultJumpForce;
    private float defaultDashSpeed;

    #region States
    public PlayerStateMachine stateMachine { get; private set;}

    public PlayerIdleState idleState { get; private set;}
    public PlayerMoveState moveState { get; private set;}
    public PlayerJumpState jumpState { get; private set;}
    public PlayerAirState airState { get; private set;}
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set;}
    public PlayerDeadState deadState {get; private set;}
    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");


        deadState = new PlayerDeadState(this, stateMachine, "Die");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);

        defaultMoveSpeed = moveSpeed;
        defaultJumpForce = jumpForce;
        defaultDashSpeed = dashSpeed;
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        StartCoroutine("BusyFor", .1f);
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deadState);
    }

}
