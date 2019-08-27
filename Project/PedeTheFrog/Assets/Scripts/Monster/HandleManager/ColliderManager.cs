using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public bool checkTrigger = false;//Trigger (true: follow MC/ false: stop)

    /*public bool CheckTrigger
    {
        get
        {
            return checkTrigger;
        }
        set
        {
            checkTrigger = value;
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        checkTrigger = false;
    }
    //Trigger of collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MC")
        {
            checkTrigger = true;
        }      
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "MC":
                checkTrigger = false;
                break;
        }
    }*/

    //Collision of collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MC")
        {
            //Destroy(this.gameObject);
        }
    }
    //public 
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
