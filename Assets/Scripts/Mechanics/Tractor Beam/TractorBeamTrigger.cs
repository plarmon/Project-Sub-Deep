using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamTrigger : MonoBehaviour
{

    [SerializeField] public Transform target;
    [SerializeField] private float scaleInc;
    [SerializeField] private float pullForce;
    private Vector3 scaleVector;
    public Vector3 startingScale;
    public Vector3 startingPos;
    public bool extending = true;

    // Start is called before the first frame update
    void Start()
    {
        scaleVector = new Vector3(0, scaleInc, 0);
        startingScale = transform.localScale;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (extending)
        {
            transform.position -= (target.up * scaleInc * Time.deltaTime);
            transform.localScale += (scaleVector * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Environment"))
        {
            extending = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Environment"))
        {
            extending = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Hit");
            Vector3 destination = target.position - other.gameObject.transform.position;
            other.GetComponent<Rigidbody>().AddForce(destination.normalized * pullForce, ForceMode.Force);
        }
    }
}
