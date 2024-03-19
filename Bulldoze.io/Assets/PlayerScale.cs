using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public float scale;

    public float maxScale;

    public float score;

    public int level;

    public Vector3 vectorScale;

    // Start is called before the first frame update
    void Start()
    {
        vectorScale = new Vector3(1, 1, 1);
        scale = 1;
        level = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Levelling();
    }

    public void Levelling()
    {
        if (level == maxScale) return;

        float scoreForNextLevel = Mathf.Pow(level + 1, 3);

        if (score >= scoreForNextLevel)
        {
            UpdateScale();
        }
    }

    public void UpdateScale()
    {
        scale++;
        level++;

        vectorScale = new Vector3(scale, scale, scale);

        transform.localScale = vectorScale;
    }
}
