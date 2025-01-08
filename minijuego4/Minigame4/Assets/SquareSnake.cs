using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareSnake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    public int foodCount = 0; // Contador de SquareFood
    public int winCount = 3; // Número necesario para ganar

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }


    }

    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);

    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);

        foodCount++;

        // Verificar si se alcanzó la condición para ganar
        if (foodCount == 3)
        {
            WinGame();
        }

    }

    private void ResetState()
    {
        for (int i = 1; i<_segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;

        // Reiniciar el contador de comida
        foodCount = 0;
    }

    private void WinGame()
    {
        Debug.Log("¡Has ganado!\nLa palabra secreta es:\n**********PEPITA**********");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SquareFood")
        {
            Grow();
        }

        if (other.tag == "SquareWall")
        {
            ResetState();
        }
    }
}
