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
    
    private Rigidbody2D rbody2D;
    private NotesSystem nsystem;
    private DialogueSystem dsystem;
    private Vector3 lastPosition;

    private bool isInteracting = false;
    private SimpleAnimator animator;

    public bool isInteractingNow()
    {
        return isInteracting;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<SimpleAnimator>();
        rbody2D = GetComponent<Rigidbody2D>();
        nsystem = GameObject.FindGameObjectWithTag("Scene").GetComponent<NotesSystem>();
        dsystem = GameObject.FindGameObjectWithTag("Scene").GetComponent<DialogueSystem>();
    }

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update() {
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveY = CrossPlatformInputManager.GetAxis("Vertical");
        bool jumpButton = CrossPlatformInputManager.GetButtonUp("Interaction");
        if (nsystem.isShowing || dsystem.isShowing)
        {
            moveX = 0;
            moveY = 0;
            jumpButton = false;
        }

        GameObject closestIntObj = FindClosestIntObj();
        Vector3 intPointPosition = transform.FindChild("InteractionPoint").transform.position;

        if (closestIntObj != null && closestIntObj.GetComponent<InteractableObject>() != null)
        {
            if (!isInteracting && Distance2D(intPointPosition - closestIntObj.transform.position) < closestIntObj.GetComponent<InteractableObject>().radius)
            {
                int direction = GetIntDirection(closestIntObj.transform.position.x - intPointPosition.x, closestIntObj.transform.position.y - intPointPosition.y);
                if (jumpButton)
                {
                    if (closestIntObj.GetComponent<InteractableObject>().useFacingDirection)
                    {
                        if (direction == animator.direction)
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
            animator.direction = direction;
        }

        float speed = Distance2D(transform.position - lastPosition);
        if (speed > 0.01f)
        {
            animator.speed = 0.2f;

        }
        else
        {
            animator.speed = 0;
        }

        animator.isInteracting = isInteracting;

        if (nsystem.isShowing || dsystem.isShowing)
        {
            lastPosition = transform.position;
            animator.speed = 0;
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
            Vector3 diff = new Vector3(go.transform.position.x - position.x, go.transform.position.y - position.y, 0);
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
        if (!nsystem.isShowing || !dsystem.isShowing)
        {
            rbody2D.MovePosition(rbody2D.position + (new Vector2(currentSpeed.x * maxSpeedX, currentSpeed.y * maxSpeedY) * Time.deltaTime));
            lastPosition = transform.position;
        }
    }

    float Distance2D(Vector3 vec)
    {
        return Mathf.Sqrt(
          Mathf.Pow(vec.x, 2f) +
          Mathf.Pow(vec.y, 2f) +
          Mathf.Pow(0, 2f));
    }
}
