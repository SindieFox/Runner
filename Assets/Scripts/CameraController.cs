using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(5f, 1.5f, -10f);
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;


    private void Update()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.2f);
    }
}
