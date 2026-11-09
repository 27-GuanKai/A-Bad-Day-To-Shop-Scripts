using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door2Script : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            if (TS2.ExitKeyCard >= 1)
            {
                print("opened");
                dooranimation.SetBool("IsBoolOpen", true);
            }
            else
            {
                Sub.GetComponent<Text>().text = ("You Need to find the Keycard for this door");
            }
        }

    }
}
