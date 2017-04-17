using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildVillagerCreatorScript : MonoBehaviour {

    public GameObject childVillager;

    public void CreateChildVillager(Vector3 destination)
    {
        GameObject childVillagerInstance = Instantiate(childVillager);
        childVillagerInstance.transform.position = transform.position;
        childVillagerInstance.GetComponent<ChildVillagerScript>().Destination = destination;
    }
}
