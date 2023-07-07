using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class ItemGod : ItemBase
{
    //public Player _player;
    
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        _player._playerCondition = PlayerCondition.God;
        Destroy(gameObject);
    }

   
}
