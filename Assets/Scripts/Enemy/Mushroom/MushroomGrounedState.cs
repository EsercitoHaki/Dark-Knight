using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomGrounedState : EnemyState
{
    protected Enemy_Mushroom enemy;
    protected Transform player;
    public MushroomGrounedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Mushroom _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();

        // player = PlayerManager.instance.player.transform;
        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < 2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
