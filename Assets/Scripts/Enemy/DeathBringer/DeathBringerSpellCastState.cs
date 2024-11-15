using UnityEngine;


public class DeathBringerSpellCastState : EnemyState
{
    private Enemy_DeathBringer enemy;

    private int amountOfSpells;
    private float spellTimer;

    public DeathBringerSpellCastState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_DeathBringer _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        amountOfSpells = enemy.amountOfSpells;
        spellTimer = .5f;
    }

    public override void Update()
    {
        base.Update();

        spellTimer -= Time.deltaTime;

        if (CanCast())
            enemy.CastSpell();


        if (amountOfSpells <= 0)
            stateMachine.ChangeState(enemy.teleportState);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeCast = Time.time;
    }

    private bool CanCast()
    {
        if (amountOfSpells > 0 && spellTimer < 0)
        {
            amountOfSpells--;
            spellTimer = enemy.spellCooldown;
            return true;
        }

        return false;
    }
}
