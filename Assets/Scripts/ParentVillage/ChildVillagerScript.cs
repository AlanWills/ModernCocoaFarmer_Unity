using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildVillagerScript : MonoBehaviour
{
    public const float Threshold = 0.1f;
    public float Speed = 0.1f;

    private Vector3 destination;
    public Vector3 Destination
    {
        set
        {
            destination = value;
            GetComponent<SpriteRenderer>().flipX = (destination.x - transform.position.x) < 0;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 diff = destination - transform.position;

		if (diff.sqrMagnitude <= Threshold)
        {
            Destroy(gameObject);
        }

        transform.position += diff.normalized * Speed * TimeManager.DeltaTime;
	}
}
