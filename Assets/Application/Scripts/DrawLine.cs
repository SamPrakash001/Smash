using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour, IBeginDragHandler, IDragHandler ,IPointerDownHandler
{
    [SerializeField] LineRenderer _line;
    [SerializeField] private int _max_count;
    private GameObject _player; 
    RaycastHit _hit;
    public List<Vector3> _points;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _player = GameObject.FindWithTag("Player");
    }
    
    
    public void OnDrag(PointerEventData data)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        
        if (data.dragging)
        {
            if (Physics.Raycast(ray, out _hit ) && _line.positionCount < _max_count)
            {
                _line.positionCount ++ ;
                if (_line.positionCount <= 1)
                {
                    Vector3 _player_Pos = new Vector3(_player.transform.position.x, 0.1f, _player.transform.position.z);
                    _line.SetPosition(0,_player_Pos);
                }
                else
                {
                    Vector3 _point = new Vector3(_hit.point.x, 0.1f, _hit.point.z);
                    _line.SetPosition(_line.positionCount -1,_point);
                    _points.Add(_point);
                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _line.positionCount = 0;
        _points.Clear();
        _line.gameObject.SetActive(true);
        FindObjectOfType<EnemyMovement>().StartTrack();
    }

    public void DisableLine()
    {
        _line.gameObject.SetActive(false);
    }
    
}


