using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private int _Damage;

    [SerializeField] private PlayerHealth _Health;

  [SerializeField]  private float _damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hitter"))
        { 
            _damage = _Health._My_Helth - _Damage;
            StartCoroutine("Active_Damage");
        }
    }

    IEnumerator Active_Damage()
    {
        while (_Health._Health_bar.fillAmount > _damage/100f)
        {
            Debug.Log("sSAdadadadasd");
            _Health._My_Helth -= _Damage;
            _Health._Health_bar.fillAmount -= 0.01f;
            yield return null;
        }

    }
}
