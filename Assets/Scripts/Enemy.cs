using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float range = 50f;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float speed = 50f;
    /*[SerializeReference]*/ public Vector3 direction;
    [SerializeField] private float distanceMag;
    public bool freeze = false;
    [SerializeField] private float freezeTimer = 0f;
    [SerializeField] private float freezeMax = 2f;
    private Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = target.transform.position - transform.position;
        distanceMag = distance.magnitude;
        if(distanceMag < range)
        {
            direction = distance.normalized;
        }

        if(!freeze) enemyRB.velocity = new Vector3(direction.x, enemyRB.velocity.y, direction.z) * speed;

        if(freeze)
        {
            freezeTimer += Time.deltaTime;
            if(freezeTimer > freezeMax)
            {
                freezeTimer = 0f;
                freeze = false;
            }
        }
    }
}
