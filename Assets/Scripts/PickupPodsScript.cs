using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickupPodsScript : MonoBehaviour {

    public int PodsPickedUp { get; private set; }

	// Use this for initialization
	void Start () {
        PodsPickedUp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);

            PodsPickedUp++;
        }
    }
}
