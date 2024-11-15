using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeathBringerTriggers : Enemy_AnimationTriggers
{
    private Enemy_DeathBringer enemyDeathBringer => GetComponentInParent<Enemy_DeathBringer>();

    private void Relocate() => enemyDeathBringer.FindPosition();

    private void MakeInvisible() => enemyDeathBringer.fx.MakeTransprent(true);
    private void MakeVisible() => enemyDeathBringer.fx.MakeTransprent(false);
}
