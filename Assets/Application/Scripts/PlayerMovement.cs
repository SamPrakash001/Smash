using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public List<Vector3> _points;
    private NavMeshAgent _agent;
    [SerializeField] private int _count;
    [Header("Reset")] [SerializeField] private Vector3 _old_pos;
    private GameManager _GM;
    
    void Start()
    {
        _GM = FindObjectOfType<GameManager>();
        _points = FindObjectOfType<DrawLine>()._points;
        _agent = GetComponent<NavMeshAgent>();
        _old_pos = transform.position;
    }

    void Update()
    {
        Movement();
    }
    
    void Movement()
    {
        if (_points.Count != _count && _GM._game_start )
        {
            Vector2 my_pos = new Vector2( (float)System.Math.Round(transform.position.x, 4) ,(float)System.Math.Round(transform.position.z, 4));
            if (_points.Count > 0)
            {
                Vector2 _point_pos = new Vector2((float)System.Math.Round(_points[_count].x, 4), (float)System.Math.Round(_points[_count].z, 4));
                float _dis = Vector3.Distance(my_pos, _point_pos);

                if (_dis > 1f)
                {
                    _agent.SetDestination(_points[_count]);
                }
                else if (_count == _points.Count - 1)
                {
                    _points.Clear();
                    FindObjectOfType<DrawLine>().DisableLine();
                }
                else
                {
                    _count++;
                }
            }
            else { _GM._playerpos=true; _GM.EndStage(); return; }
        }
        else
        {
            _count = 0;
        } 
    }


}
