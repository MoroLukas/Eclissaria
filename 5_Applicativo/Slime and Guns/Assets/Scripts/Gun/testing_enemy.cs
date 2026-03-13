using UnityEngine;
using UnityEngine.InputSystem;

public class testing_enemy : MonoBehaviour
{
    public float speed = 5f;
    public GameObject ColorPrefab;

    private Vector2 targetPoint;
    private bool targetSet = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!targetSet)
        {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 origin = transform.position;
            Vector2 direction = (worldPos - transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, 100f);

            if (hit.collider != null)
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = worldPos;
            }

            targetSet = true;
        }
        else
        {
            Vector2 direction = targetPoint - (Vector2)transform.position;

            if (direction.magnitude < 0.1f)
            {
                Destroy(gameObject);
                return;
            }

            rb.linearVelocity = direction.normalized * speed;
        }
    }

    private void OnDestroy()
    {
        Instantiate(ColorPrefab, transform.position, Quaternion.identity);
    }
}