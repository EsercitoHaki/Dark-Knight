using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected float stateTimer;
    protected bool triggerCalled;
    private string animBoolName;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer += Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        enemy.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);
    }
}
