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


    [Header("Ink Manage")]
    private InkSystem _inkSystem;

     
    void Start()
    {
        _inkSystem = InkSystem.Instence;
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
        if (_points.Count != _count && _GM._game_start)
        {
            Vector2 my_pos = new Vector2((float)Math.Round(transform.position.x, 4), (float)Math.Round(transform.position.z, 4));
            if (_points.Count > 0)
            {
                Vector2 _point_pos = new Vector2((float)Math.Round(_points[_count].x, 4), (float)Math.Round(_points[_count].z, 4));
                float _dis = Vector3.Distance(my_pos, _point_pos);

                if (_dis > 1f)
                {
                    if (_inkSystem.inkAmount >= 0)
                    {
                        _inkSystem.inkAmount -= Time.deltaTime * _inkSystem.leakMultiplier;
                        InkSystem.Instence.CheckInk();
                        _agent.SetDestination(_points[_count]);
                    }
                }
                else if (_count == _points.Count - 1)
                {
                    Debug.Log("Ended");
                    _points.Clear();
                    FindObjectOfType<DrawLine>().DisableLine();
                }
                else
                {
                    Debug.Log("count ++");
                    _count++;
                }
            }
            else { _GM._playerpos = true; _GM.EndStage(); return; }
        }
        else
        {
            _count = 0;
        } 
    }


}
