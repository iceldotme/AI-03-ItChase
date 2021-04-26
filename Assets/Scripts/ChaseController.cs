using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    bool it;
    private void OnCollisionEnter(Collision collision) {
        it = GetComponent<MoveCharacter>().it;
        if (it) {
           GetComponent<MoveCharacter>().it = false;
        } else {
            GetComponent<MoveCharacter>().it = true;
        }
    }
}