using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel
{
    public int playerNumber;
    public float moveSpeed;
    public float maxSpeed;
    public float maxAccel;
    public float moveSpeedInAir;
    public float jumpForce;
    public float divingForce;
    public float grabRadius;
    public float grabForce;
}
