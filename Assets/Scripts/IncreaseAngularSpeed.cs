using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAngularSpeed : MonoBehaviour
{
    [SerializeField]
    float maxAngVel = 10f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = maxAngVel;
    }
}
