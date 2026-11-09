using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScript : MonoBehaviour
{
    public Text ScoreText;
    public Text AmmoText;
    public PlayerInteraction PI;
    float Score;
    float Health;
    float Ammo;
    // Update is called once per frame
    void Update()
    {
        Score = PI.Score;
        Ammo = PI.Ammo;
        ScoreText.GetComponent<Text>().text = (""+Score);
        AmmoText.GetComponent<Text>().text = ("" + Ammo);
    }
}
