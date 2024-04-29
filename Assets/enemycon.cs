using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycon : MonoBehaviour
{

    public float time;
    public float EnemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,time);
            
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = EnemySpeed;

        this.transform.Translate(speed);
    }
}
