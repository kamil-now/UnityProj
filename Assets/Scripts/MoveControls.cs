using System.Linq;
using System.Timers;
using UnityEngine;

public class MoveControls : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    private bool playerMoving;
    private Vector2 lastMove;
    [SerializeField]
    private string horizontalAxis;
    [SerializeField]
    private string verticalAxis;
    [SerializeField]
    private string gameObjectId = "";
    private Controls controls;
    private Vector3 pos;
    private Transform tr;
    private bool canMove = true;
    private Timer movementTimer = new Timer(200);

    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 5;
        gameObject.tag.Where(c => c >= '0' && c <= '9').ForEach(x => gameObjectId += x);


        if (gameObjectId == "1")
        {
            controls = new Controls()
            {
                DownKey = KeyCode.DownArrow,
                UpKey = KeyCode.UpArrow,
                LeftKey = KeyCode.LeftArrow,
                RightKey = KeyCode.RightArrow
            };
        }
        else
        {
            controls = new Controls()
            {
                DownKey = KeyCode.S,
                UpKey = KeyCode.W,
                LeftKey = KeyCode.A,
                RightKey = KeyCode.D
            };
        }

        horizontalAxis = "Horizontal" + gameObjectId;
        verticalAxis = "Vertical" + gameObjectId;
        pos = transform.position;
        tr = transform;

        movementTimer.Elapsed += (s, e) => { canMove = true; movementTimer.Stop(); };
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.gameObject.tag);
        if (!col.collider.gameObject.tag.Contains("Box"))
            pos = previousPosition;
    }
    Vector3 previousPosition;
    void Update()
    {
        playerMoving = false;

        var horizontal = Input.GetAxisRaw(horizontalAxis);
        var vertical = Input.GetAxisRaw(verticalAxis);
        if (Input.GetKey(controls.RightKey) && canMove)
        {
            previousPosition = pos;
            pos += Vector3.right;
            canMove = false;
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.LeftKey) && canMove)
        {
            previousPosition = pos;
            pos += Vector3.left;
            canMove = false;
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.UpKey) && canMove)
        {
            previousPosition = pos;
            pos += Vector3.up;
            canMove = false;
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.DownKey) && canMove)
        {
            previousPosition = pos;
            pos += Vector3.down;
            canMove = false;
            movementTimer.Start();
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);


        if (horizontal > 0.5f || horizontal < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0f);
        }
        if (vertical > 0.5f || vertical < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, vertical);
        }

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }
    struct Controls
    {
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
    }
}
