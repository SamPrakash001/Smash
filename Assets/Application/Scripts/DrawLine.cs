using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;
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
        _line.positionCount = 0;
        _points.Clear();
    }
    
    
    public void OnDrag(PointerEventData data)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        var _time = FindObjectOfType<TImer>().timeRemaining;
        
        if (data.dragging && _time > 5)
        {
            if (Physics.Raycast(ray, out _hit ) && _line.positionCount < _max_count)
            {
                _line.positionCount ++ ;
                if (_line.positionCount <= 1)
                {
                    _line.SetPosition(0,_player.transform.position);
                }
                else
                {
                    _line.SetPosition(_line.positionCount -1,_hit.point);
                    _points.Add(_hit.point);
                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _line.gameObject.SetActive(true);
    }

    public void DisableLine()
    {
        _line.gameObject.SetActive(false);
    }
    
}


