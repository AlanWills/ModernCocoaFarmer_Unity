using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveCreatorScript : MonoBehaviour {

    public GameObject Grave;
    public int ColumnCount;

    public void CreateGrave()
    {
        int currentCount = transform.childCount;
        int row = currentCount / ColumnCount;
        int column = currentCount % ColumnCount;

        Vector3 spacing = Grave.GetComponent<SpriteRenderer>().bounds.extents * 2;

        GameObject newGrave = Instantiate(Grave, transform);
        newGrave.transform.localPosition = new Vector3((spacing.x + 0.025f) * column, -(spacing.y + 0.05f) * row, 0);
    }
}
