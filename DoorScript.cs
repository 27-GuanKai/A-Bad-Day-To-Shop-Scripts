using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class DoorScript : MonoBehaviour
{
    Animator dooranimation;
    public TextScript2 TS2;
    public Text Sub;
    // Start is called before the first frame update
    void Start()
    {
        dooranimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(TS2.SecurityKeycard >=1)
            print("opened");
            dooranimation.SetBool("IsBoolDoorOpen", true);
        }
        else
        {
            Sub.GetComponent<Text>().text = ("You Need to find the Keycard for this door");
        }
    }

}
