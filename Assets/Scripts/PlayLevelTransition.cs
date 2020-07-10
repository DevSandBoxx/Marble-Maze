using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelTransition : MonoBehaviour
{
    Rigidbody marble;
    // Start is called before the first frame update
    void Start()
    {
        marble = GameObject.Find("Marble").GetComponent<Rigidbody>();
        marble.useGravity = false;
        StartCoroutine(startLevel());
    }
    IEnumerator startLevel()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        marble.useGravity = true;
    }
}
