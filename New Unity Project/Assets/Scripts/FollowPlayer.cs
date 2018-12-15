using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float damping = 1;

    private GameObject target;
    private Vector3 offset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(target.transform);
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;
    }
}
