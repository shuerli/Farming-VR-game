using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformBurger : MonoBehaviour
{
    public GameObject Cake;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball"){
            Instantiate(Cake, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
