using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] string scene;
    
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void SceneChange()
    {
        gm.SceneTransition(scene);
    }
}
