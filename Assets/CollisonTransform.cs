using UnityEngine;
using System.Collections;

public class CollisionTransform : MonoBehaviour
{
    public GameObject Cake;

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(Cake);
        Destroy(gameObject);
    }
}