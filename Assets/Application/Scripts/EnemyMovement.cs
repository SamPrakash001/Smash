using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public Transform _player;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] private int _max_waypoint;
    private NavMeshAgent _nav_mesh;
    
    public GameObject _points;
    public float xRange = 10.0f;
    public float zRange = 10.0f;
    
    private Transform _me;

   [SerializeField] private List<Vector3> _WayToGo;
   [SerializeField] private int _count;
   private GameManager _GM;

    void Start()
    {
        _nav_mesh = GetComponent<NavMeshAgent>();
        _me = this.transform;
        _GM = FindObjectOfType<GameManager>();

        StartTrack();
    }
    
    public void StartTrack()
    {
        foreach (Transform _points in waypoints)
        {
            Destroy(_points.gameObject);
        }
        
        waypoints.Clear();
        _WayToGo.Clear();


        for (int i = 0; i <= _max_waypoint; i++)
        {
            CreateWaypoints();        
        }
        Invoke("AddWaypoints",1f);
    }
    
    void CreateWaypoints()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-xRange, xRange),
            0,
            Random.Range(-zRange, zRange)
        );

       GameObject _waypoint =  Instantiate(_points, randomPosition, Quaternion.identity);
       waypoints.Add(_waypoint.transform);
    }


    void AddWaypoints()
    {
        for (int i = 0; i < 2; i++)
        {
            _WayToGo.Add(waypoints[i].position);
            if (i == 1)
            {
                _WayToGo.Add(_player.position);
            }
        }
    }
    
    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (_GM._game_start)
        {
            Vector2 my_pos = new Vector2( _me.position.x,_me.position.z);
            if (_WayToGo.Count > 0)
            {
                Vector2 _point_pos = new Vector2(_WayToGo[_count].x, _WayToGo[_count].z);

                float _dis = Vector3.Distance(my_pos, _point_pos);

                if (_dis > 1f)
                {
                    _nav_mesh.SetDestination(_WayToGo[_count]);
                }
                else if (_count == _WayToGo.Count - 1)
                {
                    _WayToGo.Clear();
                }
                else
                {
                    _count++;
                }
            }
            else { _GM._enemypos = true; _GM.EndStage(); return; }
        } 
        else
        {
            _count = 0;
        } 
    }
}
