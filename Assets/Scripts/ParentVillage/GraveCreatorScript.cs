using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveCreatorScript : MonoBehaviour {

    public GameObject Grave;
    public int ColumnCount;

    private Vector3 spacing;

    void OnStart()
    {
        spacing = Grave.GetComponent<SpriteRenderer>().sprite.bounds.extents * 2;
    }
    
    public void CreateGrave()
    {
        int currentCount = transform.childCount;
        int row = currentCount / ColumnCount;
        int column = currentCount % ColumnCount;

        GameObject newGrave = Instantiate(Grave, transform);
        newGrave.transform.localPosition = new Vector3(spacing.x * column, spacing.y * row, 0);
    }
}
