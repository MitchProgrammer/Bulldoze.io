using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public PlayerScale player;

    public Rigidbody rb;

    public Transform playerTransform;

    public int scale;
    public int heightMultiplier;

    public float bulldozeForce;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vectorScale = new Vector3(scale, scale*heightMultiplier, scale);
        transform.localScale = vectorScale;

        float yPos = (scale*heightMultiplier / 2f) + 0.1f;
        rb.position = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        score = scale * heightMultiplier;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if ((scale <= player.scale) && (other.tag == "Player"))
        {
            Debug.Log("Collision is player");
            rb.constraints = RigidbodyConstraints.None;

            this.GetComponent<BoxCollider>().enabled = false;

            rb.AddForce(playerTransform.forward * bulldozeForce, ForceMode.Force);

            player.score += score;

            StartCoroutine(Despawn());
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);

        yield return null;
    }
}