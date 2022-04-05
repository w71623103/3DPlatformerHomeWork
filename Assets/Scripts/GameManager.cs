using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int enemyCount = 6;
    [SerializeField] private TMP_Text ecount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ecount.text = enemyCount.ToString();
        if(enemyCount <= 0)
        {
            SceneManager.LoadScene("startScene");
        }
    }
}
