using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody playerRb;
    private bool isGrounded = true;
    private Vector3 collision;
    public Transform cameraTransform;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.PauseMenu();
        }
        Boundaries();
        Click();
    }

    void FixedUpdate()
    {
        BasicMovement();
    }

    void BasicMovement()
    {
        // WASD movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = move.normalized * Time.deltaTime * moveSpeed;

        playerRb.AddRelativeForce(move, ForceMode.Impulse);

        // Jump
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Boundaries()
    {
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(0, 3, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << 8;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20, layerMask))
            {
                Debug.Log("Hit " + hit.transform.gameObject.name);
                collision = hit.point;
                hit.transform.gameObject.SetActive(false);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }
}