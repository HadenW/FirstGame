using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAlly : BasePawn
{
    void Update()
    {
        HandleMovement();
        HandleAttack();
    }
}
