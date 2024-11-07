using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;

    [Header("Major stats")]
    public Stat strength;// 1 điểm sẽ tăng 1 sức mạnh và 1% tỷ lệ chí mạng
    public Stat agility;// 1 điểm sẽ tăng 1 % né tránh và 1% tỷ lệ chí mạng
    public Stat intelligence;// 1 điểm sẽ tăng 1 sát thương phép và 1% kháng phép
    public Stat vitality;// 1 điểm sẽ tăng 3 hoặc 5 máu

    [Header("Defensive stats")]
    public Stat maxHealth;//máu
    public Stat armor;//giáp
    public Stat evasion;// né tránh
    public Stat magicResistance;//kháng phép
    public int currentHealth;
    public System.Action onHealthChanged;

    [Header("Offensive stats")]
    public Stat damage;
    public Stat critChance;
    public Stat critPower;
    protected bool isDead;

    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
        fx = GetComponent<EntityFX>();
    }

    protected virtual void Update()
    {
        
    }
    protected virtual void Die()
    {
        isDead = true;
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();

        totalDamage = CheckTargerArmor(_targetStats, totalDamage);

        _targetStats.TakeDamage(totalDamage);
    }

    private int CheckTargerArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }

    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue() + vitality.GetValue() * 5;
    }

    public virtual void TakeDamage(int _damage)
    {
        DecreaseHealthBy(_damage);
        GetComponent<Entity>().DamageImpact();

        fx.StartCoroutine("FlashFX");
        if(currentHealth < 0 && !isDead)
        {
            Die();
        }
    }

    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth -= _damage;

        if(onHealthChanged != null)
        {
            onHealthChanged();
        }
    }
}
