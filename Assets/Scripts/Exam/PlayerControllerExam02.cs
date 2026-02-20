using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float yRange = 10;
    public GameObject projectilePrefab;
    private float verticalInput;

    private InputAction moveAction;
    private InputAction shootAction;
    public float autoFireInterval = 0.1f;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame

    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.right);
        if (transform.position.x < -yRange)
        {
            transform.position = new Vector3(-yRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > yRange)
        {
            transform.position = new Vector3(yRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

    }

}

