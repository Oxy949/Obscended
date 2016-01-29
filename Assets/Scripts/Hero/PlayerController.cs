using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class PlayerController : MonoBehaviour {
    public float maxSpeedX = 10f;
    public float maxSpeedY = 10f;
    public float interactionDistance = 0.2f;
    public GameObject interactionObj;
    public bool interactionObjFounded = false;
    private Vector2 currentSpeed;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private MessageSystem msystem;
    private Vector3 lastPosition;

    private bool isInteracting = false;

    public bool isInteractingNow()
    {
        return isInteracting;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        msystem = GameObject.Find("Scene").GetComponent<MessageSystem>();
    }

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update() {
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveY = CrossPlatformInputManager.GetAxis("Vertical");
        bool jumpButton = CrossPlatformInputManager.GetButtonUp("Jump");
        if (msystem.isShowing)
        {
            moveX = 0;
            moveY = 0;
            jumpButton = false;
        }

        GameObject closestIntObj = FindClosestIntObj();
        Vector3 intPointPosition = transform.FindChild("InteractionPoint").transform.position;


        if (!isInteracting && Distance(intPointPosition - closestIntObj.transform.position) < closestIntObj.GetComponent<InteractableObject>().radius)
        {
            int direction = GetIntDirection(closestIntObj.transform.position.x - intPointPosition.x, closestIntObj.transform.position.y - intPointPosition.y);
            if (jumpButton)
            {
                if (closestIntObj.GetComponent<InteractableObject>().useFacingDirection)
                {
                    if (direction == animator.GetInteger("direction"))
                    {
                        interactionObj = closestIntObj;
                        isInteracting = true;
                        StartCoroutine("Interact", interactionObj.GetComponent<InteractableObject>().interactionTime);
                    }
                }
                else
                {
                    interactionObj = closestIntObj;
                    isInteracting = true;
                    StartCoroutine("Interact", interactionObj.GetComponent<InteractableObject>().interactionTime);
                }
            }
        }

        if (!isInteracting)
            currentSpeed = new Vector2(moveX, moveY);
        else
        {
            currentSpeed = Vector2.zero;
            Debug.DrawLine(intPointPosition, closestIntObj.transform.position, Color.red);
        }


        if (currentSpeed != Vector2.zero)
        {
            int direction = GetIntDirection(moveX, moveY);
            animator.SetInteger("direction", direction);
        }

        float speed = Distance(transform.position - lastPosition);
        if (speed > 0.01f)
        {
            animator.SetFloat("speed", 0.2f);

        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        animator.SetBool("isInteracting", isInteracting);

        if (msystem.isShowing)
        {
            lastPosition = transform.position;
            animator.SetFloat("speed", 0);
        }
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
            if (moveY > 0)
                direction = 2;
        }
        else
        {
            if (moveX < 0)
                direction = 1;
            if (moveX > 0)
                direction = 3;
        }
        return direction;
    }

    IEnumerator Interact(float interactionTime)
    {
        yield return new WaitForSeconds(interactionTime);
        interactionObj.GetComponent<InteractableObject>().OnInteractionFinished();
        isInteracting = false;
        interactionObjFounded = false;
        interactionObj = null;
    }

    GameObject FindClosestIntObj()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("InteractableObject");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void FixedUpdate()
    {
        if (!msystem.isShowing)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + (new Vector2(currentSpeed.x * maxSpeedX, currentSpeed.y * maxSpeedY) * Time.deltaTime));
            lastPosition = transform.position;
        }
    }

    float Distance(Vector3 vec)
    {
        return Mathf.Sqrt(
          Mathf.Pow(vec.x, 2f) +
          Mathf.Pow(vec.y, 2f) +
          Mathf.Pow(vec.z, 2f));
    }
}
