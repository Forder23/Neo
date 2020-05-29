using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGrass : MonoBehaviour
{
    [SerializeField]
    private GameObject Spike_01;
    [SerializeField]
    private GameObject Spike_02;

    private AudioSource SnapAudio;

    private void Awake()
    {
        SnapAudio = this.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        StartCoroutine(TriggerAndDisappear(collision));
    }

    private IEnumerator TriggerAndDisappear(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SnapAudio.Play();
                yield return new WaitForSeconds(4f);
                Spike_01.SetActive(false);
                Spike_02.SetActive(false);
                this.gameObject.GetComponent<Renderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                yield return new WaitForSeconds(5f);
                this.gameObject.GetComponent<Renderer>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Spike_01.SetActive(true);
                Spike_02.SetActive(true);
            }            
        }
    }
}
