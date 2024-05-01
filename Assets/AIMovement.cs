using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject Puck;
    public GameObject home;
    public float speed;

    [SerializeField] private Vector2 minboundary;
    [SerializeField] private Vector2 maxboundary;

    private Rigidbody2D rb;


    private float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*Vector2 currentposition = rb.position;

        float clampedX = Mathf.Clamp(currentposition.x, minboundary.x, maxboundary.x);
        float clampedY = Mathf.Clamp(currentposition.y, minboundary.y, maxboundary.y);

        rb.position = new Vector2(clampedX, clampedY);*/

         distance = Vector2.Distance(transform.position, Puck.transform.position);
         Vector2 direction = Puck.transform.position - transform.position;

         direction.Normalize();
         float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

         transform.position = Vector2.MoveTowards(this.transform.position, Puck.transform.position, speed * Time.deltaTime);

         transform.rotation = Quaternion.Euler(0f, 0f, -angle);

        if (distance < 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, rb.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        if (distance > 5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, home.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        /*Vector2 targetPosition = Vector2.MoveTowards(rb.position, Puck.transform.position, speed * Time.deltaTime);

        // Clamp the target position within the bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, minboundary.x, minboundary.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minboundary.y, minboundary.y);

        rb.MovePosition(targetPosition);

        // Calculate rotation angle
        Vector2 direction = Puck.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;*/

    }
}
