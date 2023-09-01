using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requiredXp;

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    [Header("Multiplier")]
    [Range(1f,300f)]
    public float additionMultiplier= 300;
    [Range(2f,4f)]
    public float powerMultiplier = 2;
    [Range(7f,14f)]
    public float divisionMultiplier = 7;
    public TextMeshProUGUI levelUpMessageText;
    private float messageTimer;
    private const float messageDisplayTime = 3.0f;
    private bool showMessage = false;
    private AudioSource audiosource;
    
    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;
        levelUpMessageText.gameObject.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if(Input.GetKeyDown(KeyCode.F))
        GainExperienceFlatRate(20);
        if (currentXp > requiredXp)
        LevelUp();

        ShowLevelUpMessage();
        
    }
    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;
        if(FXP < xpFraction)
        {
            
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4f;
                percentComplete = percentComplete * percentComplete;
                frontXpBar.fillAmount = Mathf.Lerp(FXP,backXpBar.fillAmount, percentComplete);
            }
        }
    }
    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
        delayTimer = 0f;
        
    }

    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount= 0f;
        backXpBar.fillAmount= 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;
        ShowLevelUpMessage();
        showMessage = true;
        audiosource.Play();

    }

    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if(passedLevel < level)
        {
            float multiplier = 1+ (level - passedLevel) * 0.1f;
            currentXp += xpGained * multiplier;

        }
        {
            currentXp += xpGained;

        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    private int CalculateRequiredXp(){
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }

     public void ShowLevelUpMessage()
    {
            if (showMessage)
            {
             delayTimer += Time.deltaTime;
            levelUpMessageText.gameObject.SetActive(true);
            if (delayTimer > 3)
            {
                levelUpMessageText.gameObject.SetActive(false);
                showMessage = false;        
            }
            }
    }



    
}
