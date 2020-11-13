using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    bool _birdWasLaunched = false;
    private float _timeSittingAround;
    [SerializeField] float _launchPower = 200;
    public Text attemptsText;
    private void Awake()
    {
        _initialPosition = transform.position;
    }
    private void Update()
    {
        attemptsText.text = "Attempts: " + GameStats.attempts.ToString();
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 13 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -13 || _timeSittingAround > 2)
        {
            if(!GameStats.enemyTouched)
            {
                GameStats.attempts++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (transform.position.y> -2.25 && GetComponent<PolygonCollider2D>().enabled == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
    private void OnMouseDown()
    {
        if (!_birdWasLaunched)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        }
    }
    private void OnMouseUp()
    {
        if (!_birdWasLaunched)
        {
            var directionToInitalPosition = _initialPosition - transform.position;
            GetComponent<Rigidbody2D>().AddForce(directionToInitalPosition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<SpriteRenderer>().color = Color.white;
            _birdWasLaunched = true;
            GetComponent<LineRenderer>().enabled = false;

        }
    }
    private void OnMouseDrag()
    {
        if (!_birdWasLaunched)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y);
        }
    }
}
