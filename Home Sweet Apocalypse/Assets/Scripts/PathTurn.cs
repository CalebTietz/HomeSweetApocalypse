using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum turnIfFacing
{
    up,
    down,
    left,
    right
};

public class PathTurn : MonoBehaviour
{
    public turnIfFacing turnIfFacing;
}
