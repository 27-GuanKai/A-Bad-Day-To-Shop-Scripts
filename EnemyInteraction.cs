using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float EnemyHealth = 4;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Bullet"))
        {
            
            EnemyHealth -= 1;
            if (EnemyHealth == 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                print("Hit");
            }
        }
        
         
    }
}
