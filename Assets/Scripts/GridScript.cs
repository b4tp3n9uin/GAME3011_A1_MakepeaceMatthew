using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    RectTransform rect;

    [SerializeField]
    GameObject TilePrefab;

    [SerializeField]
    int rowsNColumns = 32;
    [SerializeField]
    float tileSpacing = 1;
    [SerializeField]
    float offsetSpacing = 10;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        GameObject referenceTile = (GameObject)Instantiate(TilePrefab);

        for (int i = 0; i < rowsNColumns; i++)
        {
            for (int j = 0; j < rowsNColumns; j++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = i * offsetSpacing * tileSpacing;
                float posY = j * offsetSpacing * tileSpacing;

                tile.transform.position = new Vector2(rect.transform.position.x + posX, rect.transform.position.x - posY);
            }
        }

        Destroy(referenceTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
