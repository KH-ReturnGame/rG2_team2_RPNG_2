using Unity.Collections;
using UnityEngine;

public class ZManage : MonoBehaviour
{
    public int defaultOrder = 1000;
    public int Zoffset = 5;
    private SpriteRenderer Part;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Part = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Check if the parent object is below the player
        Part.sortingOrder = defaultOrder - Mathf.RoundToInt(transform.position.y * Zoffset);
    }
}
