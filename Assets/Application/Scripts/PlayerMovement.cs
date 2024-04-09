using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    public List<Vector3> _points;
    private NavMeshAgent _agent;

   [SerializeField] private int _count;
   [Header("Reset")] [SerializeField] private Vector3 _old_pos;


    private TImer _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = FindObjectOfType<TImer>(); 
        _points = FindObjectOfType<DrawLine>()._points;
        _agent = GetComponent<NavMeshAgent>();
        _old_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }



    void Movement()
    {
        if (_points.Count != _count && _timer.timeRemaining == 0 )
        {
            Vector2 my_pos = new Vector2( (float)System.Math.Round(transform.position.x, 4) ,(float)System.Math.Round(transform.position.z, 4));
            Vector2 _point_pos = new Vector2((float)System.Math.Round (_points[_count].x,4),(float)System.Math.Round(_points[_count].z,4));

            float _dis =  Vector3.Distance(my_pos, _point_pos);
        
            if (_dis > 1f)
            {
                _agent.SetDestination(_points[_count]);
            }
            else if (_count == _points.Count-1)
            {
                _points.Clear();
                FindObjectOfType<DrawLine>().DisableLine();
            }
            else
            {
                _count++;
            }
            
        }
        else
        {
            _count = 0;
        } 
    }


    public void ResetHealth()
    {
        foreach (Transform _get_child in transform.GetComponentsInChildren<Transform>())
        {
            var _child = _get_child.GetComponent<PlayerHealth>();
            if (_child !=null)
            {
                _child._My_Helth = 100;
            }
        }
    }
    
}
