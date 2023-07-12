using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedWave : MonoBehaviour
{

    private float interval = 0;
    private int randDirection;

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (Random.value > 0.5)
        {
            randDirection = 1;
        }
        else
        {
            randDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.paused)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Mathf.Cos(interval) / 50 * randDirection));
            interval += Time.deltaTime;
        }
    }
}
