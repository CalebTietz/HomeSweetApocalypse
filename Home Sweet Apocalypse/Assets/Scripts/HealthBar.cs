using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthIndicator;
    public List<Color> healthGradient; // first element is full health, last element is low health

    [Range(0f, 1f)]
    public float health=1f;

    // Start is called before the first frame update
    void Start()
    {
        if (healthGradient.Count >= 2)
        {
            // initialize health bar
            healthIndicator.color = healthGradient[0];
            healthIndicator.fillAmount = 1f;
            health = 1f;

        }
        else
        {
            Debug.LogWarning("Health bar gradient does not contain at least two colors. The health bar will not function.");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        setFillLevel(health);
        if(health <=0){
            SceneManager.LoadScene("YouLose");
        }
    }

    public void setFillLevel(float val)
    {
        if (healthGradient.Count < 2) return; // less than two colors. Cannot apply gradient.


        Color healthColor;

        int cI = Mathf.Min(healthGradient.Count - Mathf.CeilToInt(val * (healthGradient.Count - 1)) - 1, healthGradient.Count - 2); // current upper color index

        float subDivisionSize = 1f / (healthGradient.Count - 1);

        if(health == 1f)
        {
            healthColor = healthGradient[0];
        }
        else
        {
            healthColor = healthGradient[cI + 1] + (healthGradient[cI] - healthGradient[cI + 1]) * ((val % subDivisionSize) / subDivisionSize);
        }

        healthColor.a = 1f;
        float easing = 0.3f;
        healthIndicator.color = Color.Lerp(healthIndicator.color, healthColor, easing);
        healthIndicator.fillAmount = Mathf.Lerp(healthIndicator.fillAmount, val, easing);
    }

    public void loseHealth(){

        health -= .1f;
    }
}
