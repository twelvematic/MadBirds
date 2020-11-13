using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noob : MonoBehaviour
{
    public GameObject startAgainCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(collision.gameObject.tag + " collision");
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().time = 0.4f;
                GetComponent<AudioSource>().Play();
                GameStats.enemyTouched = true;
                startAgainCanvas.GetComponent<StartAgainCanvas>().setActive();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
    private void OnTriggerStay(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
