using System.Linq;
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
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 5;
        gameObject.tag.Where(c => c >= '0' && c <= '9').ForEach(x => gameObjectId += x);
        horizontalAxis = "Horizontal" + gameObjectId;
        verticalAxis = "Vertical" + gameObjectId;

    }

    void Update()
    {
        playerMoving = false;
        var horizontal = Input.GetAxisRaw(horizontalAxis);
        var vertical = Input.GetAxisRaw(verticalAxis);
        if (horizontal > 0.5f || horizontal < -0.5f)
        {
            transform.Translate(new Vector3(horizontal * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0f);
        }
        if (vertical > 0.5f || vertical < -0.5f)
        {
            transform.Translate(new Vector3(0f, vertical * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, vertical);
        }
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }

}
