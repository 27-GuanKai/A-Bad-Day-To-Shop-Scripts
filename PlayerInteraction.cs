using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class PlayerInteraction : MonoBehaviour
{
    public int Health = 150;
    public float Score = 0;
    public float Ammo =20;
    public TextScript TS;
    public Text Sub;
    
    public HealthBar healthbar;
    public int currenthealth;
    public void Start()
    {
        currenthealth = Health;
        healthbar.SetMaxHealth(Health);
    }
    public void Update()
    {
        healthbar.setHealth(currenthealth);
        Dead();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Med"))
        {
            if (currenthealth < 150)
            {
                currenthealth =150;
                print("Heal");
                Destroy(other.gameObject);
                Sub.text = ("Health has been healed");
            }
            else if (Health == 150)
            {
                Sub.text = ("Health is already maxed");
            }
        }
        if (other.gameObject.tag == ("Ammo"))
        {
            Ammo += 10;
            print("pick up");
            Destroy(other.gameObject);
            Sub.text = ("Picked Up 10 Ammo");
        }
        if (other.gameObject.tag == ("Score"))
        {
            Score += 1;
            print("Score");
            Destroy(other.gameObject);
            Sub.text = ("You Earned 1 Point!");
        }
        if (other.gameObject.tag == ("Finish"))
        {
            if(Score == 4)
            {
                SceneManager.LoadScene("Level 2");
            }
            else
            {
                Sub.text = ("You Need to Find " + (4 - Score) + " more Food(s)");
            }
        }
        if (other.gameObject.tag == ("Exit"))
        {
            if (Score == 4)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                Sub.text = ("You Need to Find " + (4 - Score) + " more Food(s)");
            }
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            damage(1);
            print("Hurt");
        }
        
    }
    void damage(int damage)
    {
        currenthealth -= damage;
        healthbar.setHealth(currenthealth);
    }
    void Dead()
    {
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }




}
