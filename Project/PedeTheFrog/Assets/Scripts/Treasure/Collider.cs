using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "MC")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Gameplay2");
        }
    }
}
