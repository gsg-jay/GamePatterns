using UnityEngine;

public class ThirdPersonPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private Rigidbody rb;
    private float nextFireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(movement));

        // Rotation (facing direction)
        Vector3 rotationInput = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        transform.Rotate(Vector3.up * rotationInput.x * rotationSpeed * Time.deltaTime);

        // Shooting
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Add shooting sound or visual effects
    }
}
