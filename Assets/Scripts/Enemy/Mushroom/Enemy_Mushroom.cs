using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : Enemy
{
    #region States
    public MushroomBattleState battleState { get ; private set; }
    public MushroomAttackState attackState { get ; private set; }
    public MushroomIdleState idleState { get ; private set; }
    public MushroomDeadState deadState { get ; private set; }
    public MushroomMoveState moveState { get ; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        
        idleState = new MushroomIdleState(this, stateMachine, "Idle", this);
        moveState = new MushroomMoveState(this, stateMachine, "Move", this);
        battleState = new MushroomBattleState(this, stateMachine, "Move", this);
        attackState = new MushroomAttackState(this, stateMachine, "Attack", this);
        deadState = new MushroomDeadState(this, stateMachine, "Death", this);
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
