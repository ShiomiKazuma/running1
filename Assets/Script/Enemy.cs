using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //ëñóÕí≤êÆ
    [SerializeField] public float move_power;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(-1 * transform.right * move_power, ForceMode2D.Force);
    }
}
