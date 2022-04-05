using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCol : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private float knockBack = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < 10; ++i)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                GetComponent<Enemy>().freeze = true;
                collision.gameObject.GetComponent<Player>().freeze = true;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<Enemy>().direction * knockBack, ForceMode.Impulse);
            }
        }
    }
}
