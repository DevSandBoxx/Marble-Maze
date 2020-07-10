using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLock : MonoBehaviour
{
    [SerializeField]
    GameObject key;
    void Update()
    {
        if (!key.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
