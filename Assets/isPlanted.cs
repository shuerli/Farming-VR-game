using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlanted : MonoBehaviour
{
    //The list of colliders currently inside the trigger
    private string plant;
    //public GameObject food;
    public bool isRunning = false;
    public GameObject seedling;
    bool plant_grew = false;
    public double max_height;
    public GameObject fruit;

    //called when something enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "seed"){ 
            plant = other.gameObject.name;
            Destroy(other.gameObject);
            GameObject myseed = Instantiate(seedling, transform.position,Quaternion.identity);
            myseed.transform.parent = this.gameObject.transform;
        }
    }
 
    //called when something exits the trigger
    void OnTriggerExit(Collider other)
    {
        
    }
    
    // Only call OnTriggerStay if some conditions are met
    IEnumerator OnTriggerStay(Collider other)
    {
        if (!isRunning){ 
            isRunning = true;
            Transform myTransform = transform;
            //if the object is in the list
            if (other.gameObject.tag == "seed"){ 
                Debug.Log("Have seed");
                yield return new WaitForSeconds(1);
                GetComponent<Collider>().isTrigger = false;
                //Instantiate(food, myTransform.position,myTransform.rotation);
                
            }else{
                Debug.Log("do not have seed");
            }
            isRunning = false;
        }

    }
    void OnParticleCollision(GameObject other) {
        GameObject myseedling;
        if (!plant_grew){ 
            //Debug.Log(plant.name);
            myseedling = this.gameObject.transform.GetChild(0).gameObject;
            if (myseedling.transform.localScale.x < max_height){ 
                myseedling.transform.localScale = new Vector3(myseedling.transform.localScale.x + Time.deltaTime, myseedling.transform.localScale.y  + Time.deltaTime, myseedling.transform.localScale.z + Time.deltaTime);
            }else{
                GameObject myfruit = Instantiate(fruit, myseedling.transform.position+ new Vector3(0,0.5f,0),Quaternion.identity);
                myfruit.transform.parent = myseedling.transform;
                plant_grew = true;
            }
        }
    }

}
