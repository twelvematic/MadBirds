using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAgainCanvas : MonoBehaviour
{
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setActive()
    {
        this.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameStats.enemyTouched)
        {
            this.gameObject.SetActive(true);
        }
    }
}
