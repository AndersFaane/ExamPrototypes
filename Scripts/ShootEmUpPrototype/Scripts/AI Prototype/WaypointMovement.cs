using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaypointMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int waypointIndex = 0;
    private Vector2 currentTarget;
    [SerializeField] private float speed;

    private Transform player;
    private float chaseDistance = 4;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentTarget = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        //If player is further away from patrolling enemy it wont detect you and chase you.
        if (Vector2.Distance(transform.position, player.position) > chaseDistance)
        {
            Patrolling();
        }
        //If player goes too close to enenmy it detects you and starts chasing you.
        else if (Vector2.Distance(transform.position, player.position) <= chaseDistance)
        {
            Chase();
            Attacking();
        }
        
    }

    public void Chase()
    {
        //Changes the detection distance to be longer since the enemy has already discovered you.
        //Increases the movement speed of the enemy when it has detected you and starts chasing you.
        //Always moves straight towards player as lang as player is in range.
        chaseDistance = 6;
        speed = 7;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Attacking()
    {
        
    }
    private void Patrolling()
    {
        speed = 4;
        UpdateWaypointMovement();
    }

    private void UpdateWaypointMovement()
    {
        //When enemy gets within a very short distance of current waypoint it changes the current waypoint to the next in the list.
        MoveToWaypoint();
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            //Debug.Log("Reached destination");
            NextWaypointIndex();
        }
    }

    private void NextWaypointIndex()
    {
        //Increments the waypoint number in the list.
        waypointIndex++;
        Debug.Log(waypointIndex);
        //If the current target of the enemy is the last in the list of waypoints it goes back to start.
        if (waypointIndex == waypoints.Count)
        {
            waypointIndex = 0;
        }
    }
    private void MoveToWaypoint()
    {
        //Moves the enemy gameobject towards its current target waypoint.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

       
    }


}
