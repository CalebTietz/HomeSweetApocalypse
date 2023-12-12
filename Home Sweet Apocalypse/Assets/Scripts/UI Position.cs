using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPosition : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject ScoreCounter;
    public GameObject WaveCompleteText;
    public GameObject HouseCamOutline;

    // Update is called once per frame
    void Update()
    {
        float width = Screen.width;
        float height = Screen.height;

        // position and scale health bar according to screen size
        Vector3 pos = HealthBar.transform.position;
        pos.y = height * 0.375f + transform.position.y;
        HealthBar.transform.position = pos;
        for(int i = 0; i < HealthBar.transform.childCount; i++)
        {
            HealthBar.transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width * 100f / 1920f, height * 100f / 1080f);
        }


        // position and scale wave complete text according to screen size
        pos = WaveCompleteText.transform.position;
        pos.y = height * 0.37f + transform.position.y;
        WaveCompleteText.transform.position = pos;
        WaveCompleteText.GetComponent<TextMeshProUGUI>().fontSize = width * 0.117f;


        // position and scale score counter according to screen size
        pos = ScoreCounter.transform.position;
        pos.y = height * 350f / 1080f;
        ScoreCounter.transform.position = pos;
        ScoreCounter.GetComponent<TextMeshProUGUI>().fontSize = width * 50f / 1920f;

        // scale house cam outline
        HouseCamOutline.GetComponent<RectTransform>().sizeDelta = new Vector2(width * 391f / 1920f, height * 220.65f / 1080f);
    }
}
