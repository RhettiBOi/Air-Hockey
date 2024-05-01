using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{

    private int Aiscore = 0;
    private int PlayerScore = 0;
    private int counter = 0;
    private bool iscounterzero;

    [SerializeField]
    private GameObject AIgoal;
    [SerializeField]
    private GameObject PlayerGoal;

    [SerializeField]
    Rigidbody2D rb;

    public float speed = 5f;
    public float maxspeed = 10f;

    [SerializeField]
    private float addforce = 0.5f;

    public bool canmove = true;

    public Scorecode logic;

    [SerializeField]
    private int Pucktouches = 0;    
    [SerializeField]
    private int Aitouches = 0;

    public GameObject ArrowUp;
    public GameObject ArrowDown;
    public GameObject ArrowLeft;
    public GameObject ArrowRight;
    public GameObject Puck;

    [SerializeField] private SpriteRenderer render;
    
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void FixedUpdate()
    {
        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }
    private void Start()
    { //fix counter

        counter = 3;
        iscounterzero = false;
        //Move();
        canmove = false;
    }

    private void fixedupdate()
    {
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
        }

    }
    void Update()
    {
        // counter = counter - 1;
        // Debug.Log(counter);

        // if (counter <= 0 ) 
        // {
        //     iscounterzero = true;
        // }
        // if (iscounterzero)
        // {
        //     Move();
        // }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Move();
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionDirection = collision.contacts[0].normal;
        rb.AddForce(collisionDirection * addforce, ForceMode2D.Impulse);

        render.color = Color.black;
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 Puckmovement = rb.velocity;
            Vector2 force = Puckmovement * addforce;

            rb.AddForce(force, ForceMode2D.Impulse);

            canmove = false;
            
        }

        if (collision.transform.tag == "Player")
        {
           Pucktouches++;
           Aitouches = 0;
           if (Pucktouches > 2)
           {
               Debug.Log("player decrease");
               PlayerScore = PlayerScore - 1;
               Pucktouches = 0;
               Aitouches = 0;
                render.color = Color.black;
           }
           else if (collision.transform.tag == "AI")
           {
              Aitouches++;
              Pucktouches = 0;
              if (Aitouches > 2)
              {
                 Debug.Log("AI decrease");
                 Aiscore = Aiscore - 1;
                 Aitouches = 0;
                 Pucktouches = 0;
                    render.color = Color.black;
              }

           }

        }
    }

   /* void Move()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector3.right * Mathf.Min(rb.velocity.magnitude + speed);
    }

    void Moveleft()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = -Vector3.right * Mathf.Min(rb.velocity.magnitude + speed);
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == AIgoal)
        {
            Debug.Log("AI scored");
            Aiscore = Aiscore + 1;
            Debug.Log(Aiscore);

            rb.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;

            canmove = true;
            //Move();
            logic.Aiaddscore();
        }
        else
        if (collision.gameObject == PlayerGoal)
        {
            Debug.Log("player scored");
            PlayerScore = PlayerScore + 1;
            Debug.Log(PlayerScore);

            rb.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;

            canmove = true;
            //Moveleft();
            logic.addscore();
        }

        if (collision.gameObject == ArrowUp)
        {
            rb.AddForce(transform.up * maxspeed, ForceMode2D.Impulse);
            render.color = Color.yellow;
        }

        if (collision.gameObject == ArrowDown)
        {
            rb.AddForce(-transform.up * maxspeed, ForceMode2D.Impulse);
            render.color = Color.yellow;
        }

        if(collision.gameObject == ArrowLeft)
        {
            rb.AddForce(-transform.right * maxspeed, ForceMode2D.Impulse);
            render.color = Color.yellow;
        }

        if (collision.gameObject == ArrowRight)
        {
            rb.AddForce(transform.right * maxspeed, ForceMode2D.Impulse);
            render.color = Color.yellow;
        }

    }
}
