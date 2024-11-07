using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    //private ItemDrop myDropSystem;

    [Header("Level details")]
    [SerializeField] private int level = 1;
    
    [Range(0f, 1f)]
    [SerializeField] private float precantageModifier = .4f;

    protected override void Start()
    {
        ApplyLevelModifiers();

        base.Start();

        enemy = GetComponent<Enemy>();

        //myDropSystem = GetComponent<ItemDrop>();
    }

    private void ApplyLevelModifiers()
    {
        Modify(strength);
        Modify(agility);
        Modify(intelligence);
        Modify(vitality);
        
        Modify(damage);
        Modify(critChance);
        Modify(critPower);

        Modify(maxHealth);
        Modify(armor);
        Modify(evasion);
        Modify(magicResistance);
    }

    private void Modify(Stat _stat)
    {
        for(int i = 0; i < level; i++)
        {
            float modifier = _stat.GetValue() * precantageModifier;

            _stat.AddModifier(Mathf.RoundToInt(modifier));
        }
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
        //myDropSystem.GenerateDrop();
    }
}
