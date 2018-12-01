using UnityEngine;

public class MoveControls : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 5;
    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if (horizontal > 0.5f || horizontal < -0.5f )
        {
            transform.Translate(new Vector3(horizontal * speed * Time.deltaTime, 0f, 0f));
        }
        if (vertical > 0.5f || vertical < -0.5f)
        {
            transform.Translate(new Vector3(0f, vertical * speed * Time.deltaTime, 0f));
        }
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
    }
}
