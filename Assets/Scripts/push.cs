using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    private BoxCollider pushCol;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float maxTimer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        pushCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pushCol.enabled) timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer = 0.0f;
            pushCol.enabled = false;
        }
    }
}
