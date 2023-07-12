using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedCollisionFollow : MonoBehaviour
{

    [SerializeField] private GameObject sub;

    public Vector3 offset = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = sub.transform.position + offset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Plant"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }
}
