using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoaPodSpawnerScript : MonoBehaviour {

    public float SpawnTime = 2;
    public List<GameObject> Pods = new List<GameObject>();

    private float currentTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.childCount == 0)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > SpawnTime)
            {
                SpawnPod();
            }
        }
	}

    private void SpawnPod()
    {
        int podType = Random.Range(0, Pods.Count);
        currentTimer = 0;
        GameObject pod = Instantiate(Pods[podType]);
        pod.transform.SetParent(transform);
        pod.transform.localPosition = Vector3.zero;

        SpawnTime += 0.5f;
    }
}
