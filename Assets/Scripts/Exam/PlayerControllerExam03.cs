using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 10;
    public GameObject projectilePrefab;
    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;
    private float nextFireTime = 0f;
    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (enableAutoFireMode)
        {
            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + autoFireInterval;
            }

        }

        else
        {
            if (shootAction.triggered)
            {

                FireProjectile();

            }

        }

    }
    void FireProjectile()
    {
        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

}

