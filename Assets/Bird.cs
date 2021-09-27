using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    private Vector3 _initialPosition;
    private bool _birdWasLaunch= false;
    private float _TimeSittingAroung;

    [SerializeField] private float _launchPower = 200;


    // Start is called before the first frame update
    private void Awake()
    {
        _initialPosition = transform.position;
        
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (_birdWasLaunch && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _TimeSittingAroung += Time.deltaTime;
        }

        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10||
            _TimeSittingAroung >5)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        GetComponent<LineRenderer>().enabled = true;

    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunch = true;
        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3 (newPosition.x, newPosition.y);
    }
}
