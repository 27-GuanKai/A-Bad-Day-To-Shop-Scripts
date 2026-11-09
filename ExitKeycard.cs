using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKeycard : MonoBehaviour
{
    public TextScript2 TS2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            TS2.ExitKeyCard += 1;
            print("collided");
            Destroy(this.gameObject);
        }
            
            
    }
}
