using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class TrapScript : MonoBehaviour
{
    public PlayerInteraction PI;
    public AudioSource AS;
    public void Start()
    {
       AS =  AS.GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PI.currenthealth -= 40;
            AS.Play();
            Destroy(this.gameObject);
            print("collided");
        }
    }
}
