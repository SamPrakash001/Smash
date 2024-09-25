using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] float _rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_rotation != 0)
        {
            transform.Rotate(Vector3.up * _rotation * Time.deltaTime);
        }
    }
}
