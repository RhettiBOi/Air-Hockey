using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragMovement : MonoBehaviour
{
    [SerializeField]
    private float Forceadded = 0f;
    Vector3 difference = Vector3.zero;
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 Boundarymin = new Vector2(-5f, -5f);
    [SerializeField]
    private Vector2 Boundarymax = new Vector2(5f, 5f);

    private Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        mainCamera = Camera.main;
    }
    private void OnMouseDown()
    {
        difference = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) - difference;
        newPosition.x = Mathf.Clamp(newPosition.x, Boundarymin.x, Boundarymax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, Boundarymin.y, Boundarymax.y);
        transform.position = newPosition;
    }

    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 direction = ((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.AddForce(direction * Forceadded);
    }
}
