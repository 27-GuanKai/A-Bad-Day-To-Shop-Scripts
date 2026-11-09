using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript2 : MonoBehaviour
{
    public Text TimerText;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 900;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale >= 1)
        {
            timerdown();
        }
        else
        {
            TimerText.GetComponent<Text>().text = ("Timer Paused");
        }
    }
    void timerdown()
    {
        Timer -= Time.fixedDeltaTime;
        TimerText.GetComponent<Text>().text = ("Timer : " + Timer);
        if (Timer <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
