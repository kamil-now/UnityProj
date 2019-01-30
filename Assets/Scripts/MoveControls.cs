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
    public Vector3 positionPlayer;
    private Transform tr;
    private bool canMove = true;
    private Timer movementTimer = new Timer(200);
    public Vector3 previousPlayerPosition;
    public BoxColliderScript BoxColliderScript;


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
        positionPlayer = transform.position;
        tr = transform;

        movementTimer.Elapsed += (s, e) => { canMove = true; movementTimer.Stop(); };
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.gameObject.tag);
        if (!col.collider.gameObject.tag.Contains("Box1"))
            positionPlayer = previousPlayerPosition;
        else if (!col.collider.gameObject.tag.Contains("Player1") && col.collider.gameObject.tag.Contains("Box1"))
            positionPlayer = previousPlayerPosition;
        else if (!col.collider.gameObject.tag.Contains("Player2") && col.collider.gameObject.tag.Contains("Box1"))
            positionPlayer = previousPlayerPosition;
    }
    
    void Update()
    {
        playerMoving = false;

        var horizontal = Input.GetAxisRaw(horizontalAxis);
        var vertical = Input.GetAxisRaw(verticalAxis);
        if (Input.GetKey(controls.RightKey) && canMove)
        {
            canMove = false;
            previousPlayerPosition = positionPlayer;
            positionPlayer += Vector3.right;           
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.LeftKey) && canMove)
        {
            canMove = false;
            previousPlayerPosition = positionPlayer;
            positionPlayer += Vector3.left;           
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.UpKey) && canMove)
        {
            canMove = false;
            previousPlayerPosition = positionPlayer;
            positionPlayer += Vector3.up;
            movementTimer.Start();
        }
        else if (Input.GetKey(controls.DownKey) && canMove)
        {
            canMove = false;
            previousPlayerPosition = positionPlayer;
            positionPlayer += Vector3.down;           
            movementTimer.Start();
        }

        transform.position = Vector3.MoveTowards(transform.position, positionPlayer, Time.deltaTime * speed);


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
