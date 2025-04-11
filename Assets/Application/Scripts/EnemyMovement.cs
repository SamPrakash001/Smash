using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public Transform _player;
    private Transform _me;
    private NavMeshAgent nav_mesh;


    [SerializeField] private List<Vector3> _WayToGo;
    [SerializeField] private int _count;
    private GameManager _GM;

    void Start()
    {
        _me = this.transform;
        _GM = FindObjectOfType<GameManager>();
        nav_mesh = GetComponent<NavMeshAgent>();


        StartDraw();
    }
    
    public void StartDraw()
    {
        _WayToGo.Clear();
        Invoke("AddWaypoints", 1f);
    }


    private int randomPoints;
    void AddWaypoints()
    {
        randomPoints = Random.Range(1,8);

        for (int i = 0; i < randomPoints; i++)
        {
/*            if (i == 1)
            {
                _WayToGo.Add(_player.position);
            }
            else
            {
                _WayToGo.Add(waypoints[i].position);
            }*/

            _WayToGo.Add(WayPoints.Instance.waypoints[i].position);
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
                    nav_mesh.SetDestination(_WayToGo[_count]);
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
