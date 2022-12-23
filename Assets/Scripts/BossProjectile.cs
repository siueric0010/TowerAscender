using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : EnemyProjectile {
    void Start() {
        base.Start();
        speed = 5.5f;
        playerDamageTaken *= transform.localScale.x; // for big shot, we want it to be as much damage as the scale.
    }
}
