using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetBully : MonoBehaviour
{
    public bool holdingBottle = false;
    GameObject heldItem;
    Rigidbody heldItemRB;
    public Vector3 holdOffset;
    public float flingVelocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBottle)
        {
            heldItem.transform.position = transform.position + holdOffset;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            heldItem = other.gameObject;
            heldItemRB = heldItem.GetComponent<Rigidbody>();
            holdingBottle = true;
        } else if (other.gameObject.tag == "Player")
        {
            if (holdingBottle)
            {
                holdingBottle = false;
                heldItem = null;
                heldItemRB.velocity = new Vector3(Random.Range(-1f, 1f), 2f, Random.Range(-1f, 1f)) * flingVelocity;
                heldItemRB = null;
            }
        }
    }

}
