using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildVillagerScript : MonoBehaviour
{
    public const float Threshold = 1;
    public float Speed = 0.1f;
    public Vector3 Destination { private get; set; }

	// Update is called once per frame
	void Update ()
    {
        Vector3 diff = Destination - transform.position;

		if (diff.sqrMagnitude <= Threshold)
        {
            Destroy(gameObject);
        }

        transform.position += diff.normalized * Speed * TimeManager.DeltaTime;
	}
}
