using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainsObject : MonoBehaviour
{
    //The list of colliders currently inside the trigger
    List<string> TriggerList = new List<string>();
    public GameObject Cake;
    public bool isRunning = false;

    //called when something enters the trigger
    void OnTriggerEnter(Collider other)
    {
        //if the object is not already in the list
        if(!TriggerList.Contains(other.gameObject.name))
        {
            //add the object to the list
            TriggerList.Add(other.gameObject.name);
            other.gameObject.tag = "inBox";
        }
    }
 
    //called when something exits the trigger
    void OnTriggerExit(Collider other)
    {
        //if the object is in the list
        if(TriggerList.Contains(other.gameObject.name))
        {
            //remove it from the list
            TriggerList.Remove(other.gameObject.name);
            other.gameObject.tag = "Untagged";
        }
    }
    
    // Only call OnTriggerStay if some conditions are met
    IEnumerator OnTriggerStay(Collider other)
    {
        if (!isRunning){ 
            isRunning = true;
            Transform myTransform = transform;
            //if the object is in the list
            if(TriggerList.Contains("Bread") && TriggerList.Contains("Cheese") && other.gameObject.name == "Cheese"){ 
                Debug.Log("Have both bread and cheese");
                yield return new WaitForSeconds(5);
                
                GameObject[] inBoxObj = GameObject.FindGameObjectsWithTag("inBox");
                foreach(GameObject taggedOne in inBoxObj){
                    if (taggedOne.name == "Bread" || taggedOne.gameObject.name == "Cheese"){
                        myTransform = taggedOne.transform;
                        Destroy(taggedOne);
                    }
                }
                Instantiate(Cake, myTransform.position,myTransform.rotation);
                TriggerList.Remove("Bread");
                TriggerList.Remove("Cheese");
                
            }else{
                Debug.Log("do not have bread and cheese");
            }
            isRunning = false;
        }

    }
}
