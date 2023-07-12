using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private float animTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && animTimer <= 0)
        {
            gm.SceneTransition("Start Screen");
        }
        animTimer -= Time.deltaTime;
    }
}
