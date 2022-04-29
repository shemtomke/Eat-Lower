using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer playerSpriteNumber;
    //speed of the player to move around
    public float speed;

    //can the player move
    public bool isMove;
    //bounds to move the player in the x,y axis
    public float xBound;
    public float yBound;

    private Vector3 direction;
    private Vector3 touchPosition;

    Vector2 difference = Vector2.zero;

    Rigidbody2D rb;

    private void Start()
    {
        isMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //touch point for android devices
        if (isMove)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x, direction.y) * speed;
                Debug.Log("touch");

                if (touch.phase == TouchPhase.Ended)
                    rb.velocity = Vector2.zero;
                Debug.Log("ended");
            }
        }


        //wasd/arrow keys for standalone
        if (isMove)
        {
            float hmove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vmove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(Vector3.right * hmove,  Space.World);
            transform.Translate(Vector3.up * vmove, Space.World);
        }

        //point click - feature
        if(isMove)
        {

        }

        //make it bound to something //not make it go past the screen
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound));

    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enemy");

        //change sprite
        
    }
}
