using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{
    #region States
    public SlimeIdleState idleState { get; private set; }
    public SlimeMoveState moveState { get; private set; }
    public SlimeBattleState battleState { get; private set; }
    public SlimeAttackState attackState { get; private set; }
    //public SlimeStunnedState stunnedState { get; private set; }
    //public SlimeDeadState deathState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        
        SetupDefailtFacingDir(-1);

        idleState = new SlimeIdleState(this, stateMachine, "Idle", this);
        moveState = new SlimeMoveState(this, stateMachine, "Move", this);
        battleState = new SlimeBattleState(this, stateMachine, "Move", this);
        attackState = new SlimeAttackState(this, stateMachine, "Attack", this);
        //stunnedState = new SlimeStunnedState(this, stateMachine, "Stunned", this);
        //deathState = new SlimeDeadState(this, stateMachine, "Death", this);
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
