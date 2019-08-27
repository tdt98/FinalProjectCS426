using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private const string Tag = "Monster";
    public float m_speed;
    private Transform target;
    private ColliderManager mCollider;
 
    // Start is called before the first frame update
    void Start()
    {
        mCollider = GameObject.FindGameObjectWithTag(Tag).GetComponent<ColliderManager>();
        target = GameObject.FindGameObjectWithTag("MC").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //If trigger turn on, monster follow MC
        if(mCollider != null)
        {
            
            if (mCollider.checkTrigger == true)
            {
                //Debug.Log("cham");
                transform.position = Vector2.MoveTowards(transform.position, target.position, m_speed * Time.deltaTime);
                Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
                transform.up = direction;
            }
        }
    }
}
