using UnityEngine;
using System.Collections;

public class PlayerControllerAndroid : MonoBehaviour
{

    private Vector2 movementPreviousPosition;
    private Vector2 movementDirection;


    public float Velocity = 5.0f;

    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement() {
        if (Input.touchCount > 0) {
            if(Input.touches[0].position.x < Screen.width / 2) {
                Touch t = Input.touches[0];
                switch (t.phase) {
                    case TouchPhase.Began:
                        movementPreviousPosition = t.position;
                        break;
                    case TouchPhase.Stationary:
                        GetComponent<Rigidbody>().velocity = new Vector3(movementDirection.x, transform.position.y, movementDirection.y).normalized * Velocity;

                        /*GetComponent<Rigidbody>().AddForce(
                            new Vector3(movementDirection.x, transform.position.y, movementDirection.y) * MovementImpulse
                            );*/
                        break;
                    case TouchPhase.Moved:
                        movementDirection = t.position - movementPreviousPosition;
                        GetComponent<Rigidbody>().velocity = new Vector3(movementDirection.x, transform.position.y, movementDirection.y).normalized * Velocity;
                        /*GetComponent<Rigidbody>().AddForce(
                            new Vector3(movementDirection.x,transform.position.y, movementDirection.y) * MovementImpulse
                            );*/
                        break;
                    case TouchPhase.Ended:
                        break;
                }
            }
        }
    }

    private void Shoot() {

    }
}