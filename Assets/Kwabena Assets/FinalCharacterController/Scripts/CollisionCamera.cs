using Kwabena.FinalCharacterController;
using UnityEngine;

public class CollisionCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform facing;
    public LayerMask mask;
    public float radius = 0.3f;
    float distance;
    public float maxDistance = 5.0f;
    public float minDistance = 1.0f;
    public float height = 2;
    public float smoothTime = 0.1f;
    public float tiltSensitivity = 90;
    public float scrollSensitivity = 10;
    public float maxPitch = 75;
    public float minPitch = -75;
    float pitch = 0;
    Vector3 velocity;
    PlayerControls playerControls;

    void Reset()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Awake()
    {
        playerControls = new PlayerControls();
        distance = maxDistance;
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        Vector2 mouseInput = playerControls.PlayerLocomotionMap.Look.ReadValue<Vector2>();
        pitch -= mouseInput.y * tiltSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        float scrollInput = playerControls.ThirdPersonMap.ScrollCamera.ReadValue<float>();
        distance += scrollInput * scrollSensitivity * Time.deltaTime * distance;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        Vector3 direction = Quaternion.AngleAxis(pitch, facing.right) * -facing.forward;
        Vector3 targetPosition;
        if (Physics.CheckSphere(target.position, radius, mask.value))
        {
            targetPosition = target.position + Vector3.up * height;
        }
        else if (Physics.SphereCast(target.position, radius, direction, out RaycastHit hit, maxDistance, mask.value))
        {
            if (hit.distance > minDistance)
            {
                targetPosition = target.position + direction * Mathf.Min(hit.distance, distance);
            }
            else
            {
                targetPosition = target.position + Vector3.up * height;
            }
        }
        else
        {
            targetPosition = target.position + direction * distance;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(transform.position - direction);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
