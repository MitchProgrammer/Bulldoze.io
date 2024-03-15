using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public float scale;

    public float maxScale;

    public Vector3 vectorScale;

    // Start is called before the first frame update
    void Start()
    {
        vectorScale = new Vector3(1, 1, 1);
        scale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpdateScale();
    }

    public void UpdateScale()
    {
        if (scale >= maxScale) return;

        scale++;

        vectorScale = new Vector3(scale, scale, scale);

        transform.localScale = vectorScale;
    }
}
