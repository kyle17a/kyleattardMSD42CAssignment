using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float MoveSpeed = 4f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        truckmove();
        
    }
    private void truckmove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;

            var truckMovement = MoveSpeed * Time.deltaTime;

             transform.position = Vector2.MoveTowards(transform.position, targetPosition, truckMovement);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }

        else
        {
            Destroy(gameObject);
        }
    }
}
