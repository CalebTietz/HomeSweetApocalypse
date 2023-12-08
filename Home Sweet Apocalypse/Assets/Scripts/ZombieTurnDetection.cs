using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTurnDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        string tag = other.gameObject.tag;

        if (tag == null) return;

        Facing facing = gameObject.GetComponentInParent<Zombie>().getFacing();
        PathTurn pathTurn = other.gameObject.GetComponent<PathTurn>();
        if (pathTurn == null) return;
        turnIfFacing turnIfFacing = pathTurn.turnIfFacing;

        if (facing.ToString() != turnIfFacing.ToString()) return; // ensure the zombie is facing the proper direction to turn

        if (tag == "turnLeft")
        {
            gameObject.GetComponentInParent<Zombie>().turn("left");
        }

        if (tag == "turnRight")
        {
            gameObject.GetComponentInParent<Zombie>().turn("right");
        }
    }
}
