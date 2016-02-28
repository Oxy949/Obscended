using UnityEngine;
using System.Collections;

public class Simple2DWalker : MonoBehaviour
{
    public Transform target;

    public float maxSpeedX = 10f;
    public float maxSpeedY = 10f;

    private Vector2 currentSpeed;

    //private Rigidbody2D rdbody2D;
    private NotesSystem msystem;
    private Vector3 lastPosition;
    private SimpleAnimator animator;

    private bool isInteracting = false;

    private PolyNavAgent _agent;
    public PolyNavAgent agent
    {
        get
        {
            if (!_agent)
                _agent = GetComponent<PolyNavAgent>();
            return _agent;
        }
    }

    public bool isInteractingNow()
    {
        return isInteracting;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<SimpleAnimator>();
        //rdbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //if ((target.position - transform.position).normalized)
        float moveX = (target.position - transform.position).normalized.x;
        float moveY = (target.position - transform.position).normalized.y;

        if (!isInteracting)
            currentSpeed = new Vector2(moveX, moveY);
        else
        {
            currentSpeed = Vector2.zero;
        }


        if (currentSpeed != Vector2.zero)
        {
            int direction = GetIntDirection(moveX, moveY);
            animator.direction = direction;
        }

        float speed = Distance(transform.position - lastPosition);
        if (speed > 0.01f)
        {
            animator.speed = 0.2f;

        }
        else
        {
            animator.speed = 0;
        }

        animator.isInteracting = isInteracting;*/

        float moveX = (target.position - transform.position).normalized.x;
        float moveY = (target.position - transform.position).normalized.y;

        if (!isInteracting)
            currentSpeed = new Vector2(moveX, moveY);
        else
        {
            currentSpeed = Vector2.zero;
        }


        if (currentSpeed != Vector2.zero)
        {
            int direction = GetIntDirection(moveX, moveY);
            animator.direction = direction;
        }

        float speed = Distance(transform.position - lastPosition);
        //Debug.Log(speed);
        if (speed > 0)
        {
            animator.speed = 0.2f;

        }
        else
        {
            animator.speed = 0;
        }

        animator.isInteracting = isInteracting;

        agent.SetDestination(new Vector2(target.position.x, target.position.y - 0.25f));
    }

    void FixedUpdate()
    {
        //rigidbody2D.MovePosition(rigidbody2D.position + (new Vector2(currentSpeed.x * maxSpeedX, currentSpeed.y * maxSpeedY) * Time.deltaTime));
        lastPosition = transform.position;
    }

    private int GetIntDirection(float moveX, float moveY)
    {

        // 0 - d - Down
        // 1 - l - Left
        // 2 - u - Up
        // 3 - r - Right

        int direction = 0;
        if (Mathf.Abs(moveY) > Mathf.Abs(moveX))
        {
            if (moveY < 0)
                direction = 0;
            if (moveY >= 0)
                direction = 2;
        }
        else
        {
            if (moveX < 0)
                direction = 1;
            if (moveX >= 0)
                direction = 3;
        }
        return direction;
    }

    float Distance(Vector3 vec)
    {
        return Mathf.Sqrt(
          Mathf.Pow(vec.x, 2f) +
          Mathf.Pow(vec.y, 2f) +
          Mathf.Pow(vec.z, 2f));
    }
}
