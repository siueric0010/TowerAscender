using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrishotEnemyProjectile : BossProjectile {
    public EnemyProjectile trishot;
    void Start() {
        Instantiate(trishot, transform.position + new Vector3(0, 0, 1.0f), transform.rotation);
        Instantiate(trishot, transform.position + new Vector3(0, 0, -1.0f), transform.rotation);
        Instantiate(trishot, transform.position + new Vector3(0, 0, 0.0f), transform.rotation);
    }
}
