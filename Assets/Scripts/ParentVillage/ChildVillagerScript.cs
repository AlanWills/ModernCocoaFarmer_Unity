using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildVillagerScript : MonoBehaviour
{
    public float Speed = 0.5f;
    public Vector3 Destination { private get; set; }

	// Update is called once per frame
	void Update ()
    {
        Vector3 diff = Destination - transform.position;

		if (diff.sqrMagnitude <= 1)
        {
            Destroy(gameObject);
        }

        transform.position += diff.normalized * 5 * Time.deltaTime;
	}
}
