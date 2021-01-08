using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint in which we want the enemy to go

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();


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

            var truckMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

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

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
