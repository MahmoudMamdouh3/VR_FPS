using UnityEngine;

public class SitThroughMode : MonoBehaviour
{
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void LateUpdate()
    {
        transform.position = startingPosition;
    }
}