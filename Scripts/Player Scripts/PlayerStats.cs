using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    private PlayerStats p1;
    GameObject pp;


//[SerializeField]
    public Image health_Stats, stamina_Stats,environment_stats;
    public float min_environment=0.3f;
    //public Text wintext;
    public Text scoretext;
    public Text timetext;
    private int dtime;
    private int ctime;
    private int score = 0;
    void Start()
    {
        //wintext.text = "";
        score = 0;
        dtime = 300-(int)Time.time;
        ctime = 300;
        TimeUpdate();
        ScoreUpdate();
        //WinUpdate();
        pp= GameObject.FindWithTag("Player");
        p1 = pp.GetComponent<PlayerStats>();
        if (p1 == null)
        {
            Debug.Log("dfdd");
        }
        Display_HealthStats(70f);
    }
    void ScoreUpdate()
    {
        scoretext.text = "SCORE: " + score.ToString();
    }
    void TimeUpdate()
    {
        timetext.text = "TimeLeft: " + dtime.ToString();
    }
    void Update()
    {
        score = (int)(100f * 100f * (0.1f+health_Stats.fillAmount)*(environment_stats.fillAmount));
        ScoreUpdate();
        dtime = 300-(int)Time.time;
        TimeUpdate();
        if (ctime - dtime>=1)
        {
            health_Stats.fillAmount = health_Stats.fillAmount - (((ctime - dtime) * 0.8f) / 150);
            ctime = dtime;
        }
        if (dtime <= 0)
        {
            Invoke("QuitMenu", 3f);
        }
        if (p1.environment_stats.fillAmount < min_environment)
        {
            Invoke("QuitMenu", 3f);
        }
    }
    public void Display_HealthStats(float healthValue) {

        healthValue /= 100f;

        health_Stats.fillAmount = healthValue;

    }

    public void Display_StaminaStats(float staminaValue) {

        staminaValue /= 100f;
        stamina_Stats.fillAmount =  staminaValue;

    }
    public void Display_EnvironmentStats(float EnvironmentValue)
    {

        EnvironmentValue /= 100f;

        environment_stats.fillAmount = environment_stats.fillAmount - EnvironmentValue;

    }


} // class





























