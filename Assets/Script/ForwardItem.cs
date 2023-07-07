using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class ForwardItem : ItemBase
{
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
        
        Transform transform = _playerTransform;

        Vector3 pos = transform.position;
        pos.x += _player._forwardPower;

        transform.position = pos;

        Destroy(gameObject);
    }
}
