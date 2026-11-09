using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScript2 : MonoBehaviour
{
    public float SecurityKeycard;
    public float ExitKeyCard;
    public Text SKeyCard;
    public Text EKeyCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SKeyCard.GetComponent<Text>().text = ("" + SecurityKeycard);
        EKeyCard.GetComponent<Text>().text = ("" + ExitKeyCard);
    }
}
