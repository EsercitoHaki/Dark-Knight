using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NightBorne : Enemy
{
    #region States
    public NightBorneBattleState battleState { get ; private set; }
    public NightBorneAttackState attackState { get ; private set; }
    public NightBorneIdleState idleState { get ; private set; }
    public NightBorneDeadState deadState { get ; private set; }
    public NightBorneMoveState moveState { get ; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        
        

        idleState = new NightBorneIdleState(this, stateMachine, "Idle", this);
        moveState = new NightBorneMoveState(this, stateMachine, "Move", this);
        battleState = new NightBorneBattleState(this, stateMachine, "Move", this);
        attackState = new NightBorneAttackState(this, stateMachine, "Attack", this);
        deadState = new NightBorneDeadState(this, stateMachine, "Death", this);
    }

     public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);

    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
