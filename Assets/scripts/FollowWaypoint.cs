using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int rotSpeed = 2;
    private Quaternion lookRotation;
    private float distanceCheck = 0.5f;
    private int currentWaypoint = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{(this.transform.position - waypoints[currentWaypoint].position).magnitude}");
        if ((this.transform.position - waypoints[currentWaypoint].position).magnitude < distanceCheck)
        {
            currentWaypoint++;
            if( currentWaypoint >= waypoints.Count )
            {
                currentWaypoint = 0;
            }
        }
        SmoothRotation(waypoints[currentWaypoint]);
        ForwardMovement();
    }
    private void SmoothRotation(Transform target)
    {
        lookRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,
        Time.deltaTime * rotSpeed);
    }
    private void ForwardMovement()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
