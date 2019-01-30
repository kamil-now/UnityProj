using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;

public class BoxColliderScript : MonoBehaviour
{

    [SerializeField]
    private float speed;
    public Vector2 pos;
    private Transform tr;
    public Vector2 previousPosition;
    private Controls controlsArrows;
    private Controls controlsWASD;
    [SerializeField]
    private Vector2 currentPos;




    void Start()
    {
        currentPos = transform.position;
        previousPosition = transform.position;
        speed = 5;
        pos = transform.position;
        tr = transform;
        
        controlsArrows = new Controls()
        {
            DownKey = KeyCode.DownArrow,
            UpKey = KeyCode.UpArrow,
            LeftKey = KeyCode.LeftArrow,
            RightKey = KeyCode.RightArrow
        };
        controlsWASD = new Controls()
        {
            DownKey = KeyCode.S,
            UpKey = KeyCode.W,
            LeftKey = KeyCode.A,
            RightKey = KeyCode.D
        };

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
    struct Controls
    {
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Player1" || col.collider.gameObject.tag == "Player2")
        {
            currentPos = pos;
        }
        else
            pos = previousPosition;
            

        if ((col.collider.gameObject.tag.Contains("Player1") && Input.GetKey(controlsArrows.UpKey))
            || (col.collider.gameObject.tag.Contains("Player2") && Input.GetKey(controlsWASD.UpKey)))
        {
            Debug.Log("up");
            previousPosition = pos;
            pos += Vector2.up;
        }
        else if ((col.collider.gameObject.tag.Contains("Player1") && Input.GetKey(controlsArrows.DownKey))
            || (col.collider.gameObject.tag.Contains("Player2") && Input.GetKey(controlsWASD.DownKey)))
        {
            Debug.Log("down");
            previousPosition = pos;
            pos += Vector2.down;
        }
        else if ((col.collider.gameObject.tag.Contains("Player1") && Input.GetKey(controlsArrows.LeftKey))
            || (col.collider.gameObject.tag.Contains("Player2") && Input.GetKey(controlsWASD.LeftKey)))
        {
            Debug.Log("left");
            previousPosition = pos;
            pos += Vector2.left;
        }
        else if ((col.collider.gameObject.tag.Contains("Player1") && Input.GetKey(controlsArrows.RightKey))
            || (col.collider.gameObject.tag.Contains("Player2") && Input.GetKey(controlsWASD.RightKey)))
        {
            Debug.Log("right");
            previousPosition = pos;
            pos += Vector2.right;
        }



    }
}
