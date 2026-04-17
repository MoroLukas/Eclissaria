using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Movement : MonoBehaviour
{
    public Transform playerTransform;
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    private SpriteRenderer spriteRenderer;

    bool canFire = true;
    float waitingTime = 0.5f;
    float timer;

    public float distanceFromPlayer = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        Vector3 direction = mousePos - transform.position;

        Vector3 scale = Vector3.one;

        if(direction.x > 0)
        {
            scale.x = -1f;
            transform.right = direction;
        }
        else
        {
            scale.x = 1f; 
            transform.right = -direction;
        }

        transform.localScale = scale;


        if (Mouse.current.leftButton.wasPressedThisFrame && canFire)
        {
            Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            canFire = false;
        }

        if (!canFire)
        {
            timer = Time.time;

            if (timer > waitingTime)
            {
                canFire = true;
                timer = 0;
            }
        }


    }
}
