using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] public Transform moveGoal;
    [SerializeField] public float speed = 0.1f;
    [SerializeField] public float rotationSpeed = 0.03f;
    [SerializeField] public float distance = 1.5f;
    public bool it;

    // Start is called before the first frame update
    void Start() {
        it = true;
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction;

        GetComponent<Animator>().SetBool("near", false);

        Vector3 realGoal = new Vector3(moveGoal.position.x, transform.position.y, moveGoal.position.z);
        if (it) {
            direction = realGoal - transform.position;
        } else {
            direction = realGoal + transform.position;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);

        Debug.DrawRay(transform.position, direction, Color.green);

        if (direction.magnitude >= distance) {
            Vector3 pushVector = direction.normalized * speed;
            transform.Translate(pushVector, Space.World);
        } else {
            GetComponent<Animator>().SetBool("near", true);
        }
    }
}