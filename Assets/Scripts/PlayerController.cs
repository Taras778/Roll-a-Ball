using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;


    public float speed = 0;
    
    public TextMeshProUGUI countText;
    
    public GameObject winTextObject;

  
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

   
    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();
 
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    
    void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    
        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
          
            other.gameObject.SetActive(false);
           
            count = count + 1;

            SetCountText();
        }
    }

    
    void SetCountText()
    {
        
        countText.text = "Count: " + count.ToString();

        
        if (count >= 8)
        {
            
            winTextObject.SetActive(true);

          
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Destroy(gameObject);

            
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";

        }

    }


}