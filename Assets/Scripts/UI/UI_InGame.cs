using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_InGame : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Slider slider;

    private SkillManager skills;


    [Header("Souls info")]
    [SerializeField] private TextMeshProUGUI currentSouls;
    [SerializeField] private float soulsAmount;
    //[SerializeField] private float increaseRate = 100;

    void Start()
    {
        if (playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;

        skills = SkillManager.instance;
    }

    
    void Update()
    {
        UpdateSoulsUI();

    }

    private void UpdateSoulsUI()
    {
        currentSouls.text = ((int)soulsAmount).ToString();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }

}
