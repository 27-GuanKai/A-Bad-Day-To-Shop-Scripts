using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityKeycard : MonoBehaviour
{
    public TextScript2 TS2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TS2.SecurityKeycard += 1;
            print("collided");
            Destroy(this.gameObject);
        }
    }
}
