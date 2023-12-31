using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : ItemBase
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _player._playerCondition== PlayerCondition.God)
        {
            Activate();
        }

        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    public override void Activate()
    {
        Destroy(gameObject);
        _player._playerCondition = PlayerCondition.Normal;
    }

    
}
