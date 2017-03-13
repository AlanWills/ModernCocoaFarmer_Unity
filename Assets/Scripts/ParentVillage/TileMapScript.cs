using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapScript : MonoBehaviour
{
    public GameObject Tile;
    public List<GameObject> Decals = new List<GameObject>();
    public float DecalProbability;
    public int X;
    public int Y;

	// Use this for initialization
	void Start ()
    {
        AddTiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AddTiles()
    {
        SpriteRenderer renderer = Tile.GetComponent<SpriteRenderer>();
        float width = renderer.sprite.bounds.extents.x * 2;
        float height = renderer.sprite.bounds.extents.y * 2;

        float xOffset = (X - 1) * width * 0.5f;
        float yOffset = (Y - 1) * height * 0.5f;

        for (int y = 0; y < Y; ++y)
        {
            for (int x = 0; x < X; ++x)
            {
                GameObject tile = Instantiate(Tile, transform);
                tile.transform.localPosition = new Vector3(x * width - xOffset, y * height - yOffset, 0);

                AddDecal(tile);
            }
        }
    }

    private void AddDecal(GameObject tile)
    {
        if (Random.Range(0.0f, 1.0f) < DecalProbability)
        {
            int decalIndex = Random.Range(0, Decals.Count - 1);
            GameObject decal = Instantiate(Decals[decalIndex], tile.transform);
            decal.transform.localPosition = new Vector3(0, 0, -0.5f);
        }
    }
}
