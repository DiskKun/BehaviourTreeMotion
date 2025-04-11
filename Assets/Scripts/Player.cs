using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    Vector3 direction;
    Rigidbody rb;
    public bool holdingBottle = false;
    GameObject heldItem;
    Rigidbody heldItemRB;
    public Vector3 holdOffset;
    public float flingVelocity;
    public WetBully wb;
    public Slider waterMeter;
    public TextMeshProUGUI winText;
    bool freeze = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //basic movement
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (holdingBottle)
        {
            // if we're holding the bottle, update the bottle's position to next to the player
            heldItem.transform.position = transform.position + holdOffset;

            // when we press space, we stop moving and start drinking, until the bottle is knocked out of our hands.
            if (Input.GetKey(KeyCode.Space))
            {
                freeze = true;
                
            }
            if (freeze)
            {
                waterMeter.value -= Time.deltaTime;
                direction = Vector3.zero;

                // when all the water is drunk, win the game
                if (waterMeter.value == 0)
                {
                    winText.text = "You Drank all the Water!";
                    Time.timeScale = 0;
                }
            }
        } else
        {
            // if not holding the bottle, unfreeze controls
            freeze = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if we touch the bottle, and the WetBully isn't holding it, we pick it up
        if (other.gameObject.tag == "Pickup" && !wb.holdingBottle)
        {
            heldItem = other.gameObject;
            heldItemRB = heldItem.GetComponent<Rigidbody>();
            holdingBottle = true;
            wb.holdingBottle = false;
        }
    }

    public void ArmHit()
    {

        // called by the Arm script. sends the bottle flying when we get hit by it.
        if (holdingBottle)
        {
            holdingBottle = false;
            wb.holdingBottle = false;
            heldItem = null;
            heldItemRB.velocity = new Vector3(Random.Range(-1f, 1f), 2f, Random.Range(-1f, 1f)) * flingVelocity;
            heldItemRB = null;
        }
        
    }


}
