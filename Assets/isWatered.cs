using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isWatered : MonoBehaviour
{
    public double max_height;
    public GameObject fruit;
    bool plant_grew = false;
    void OnParticleCollision(GameObject other) {
        /*GameObject plant;
        if (other.name == "Dirt_Pile" && !plant_grew){ 
            Debug.Log(other.name);
            plant = other.transform.GetChild(0).gameObject;
            if (plant.transform.localScale.x < max_height){ 
                plant.transform.localScale = new Vector3(plant.transform.localScale.x + Time.deltaTime, plant.transform.localScale.y  + Time.deltaTime, plant.transform.localScale.z + Time.deltaTime);
            }else{
                GameObject myfruit = Instantiate(fruit, plant.transform.position+ new Vector3(0,0.5f,0),Quaternion.identity);
                myfruit.transform.parent = plant.transform;
                plant_grew = true;
            }
        }*/
    }
}
