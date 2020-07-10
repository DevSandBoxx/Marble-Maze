using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageMarble : MonoBehaviour
{
    [SerializeField]
    float velThreshHold = 1f;

    Rigidbody rigidbody;
    Collider collider;

    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;


    [SerializeField] AudioClip marbleRolling;
    [SerializeField] AudioClip marbleClick;
    [SerializeField] AudioClip keyCollect;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip deathSound;

    enum State {Alive, Dead};
    State playerState;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        collider = GetComponent<SphereCollider>();
        playerState = State.Alive;
    }
    void Update()
    {
        PlayRollingAudio();
    }
    void PlayRollingAudio()
    {
        if (rigidbody.velocity.magnitude > velThreshHold && !audioSource1.isPlaying
            && playerState == State.Alive)
        {
            audioSource1.PlayOneShot(marbleRolling);
        }
        else if (rigidbody.velocity.magnitude < velThreshHold || playerState == State.Dead)
        {
            audioSource1.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(playerState == State.Dead) { return; }

        if (other.gameObject.CompareTag("Hole"))
        {
            StartCoroutine(DeathSequence());
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(WinSequence());
        }
        else if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            if (keyCollect != null)
            {
                audioSource2.PlayOneShot(keyCollect);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource2.PlayOneShot(marbleClick);
        }

    }

    IEnumerator WinSequence()
    {
        audioSource2.PlayOneShot(winSound);
        yield return new WaitForSeconds(3f);
        GameManager.instance.OpenLevel(GameManager.instance.activeSceneIndex + 1);
    }
    IEnumerator DeathSequence()
    {
        collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collider.enabled = false;
        playerState = State.Dead;
        audioSource2.PlayOneShot(deathSound);
        yield return new WaitForSeconds(3f);
        GameManager.instance.OpenLevel(GameManager.instance.activeSceneIndex);
    }
}
