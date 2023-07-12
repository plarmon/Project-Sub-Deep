using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using TMPro;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private GameObject skipText;
    [SerializeField] private PlayableDirector pd;
    [SerializeField] private GameManager gm;
    [SerializeField] private float waitTimeText;
    [SerializeField] private float waitTimeStart;
    [SerializeField] private MechanicsManager mm;
    [SerializeField] private GameObject dialogueBox;
    private bool showing;
    
    void Start()
    {
        StartCoroutine("StartTimeline");
        showing = false;
    }

    public void SkipPrompt()
    {
        StartCoroutine("ShowText");
    }

    public void Skip()
    {
        if (showing)
        {
            gm.SceneTransition("Greybox Level");
        }
    }

    private IEnumerator StartTimeline()
    {
        if (mm.sonarOn)
        {
            mm.SonarToggle();
        }
        if (mm.lightsOn)
        {
            mm.LightsToggle();
        }
        yield return new WaitForSeconds(waitTimeStart);
        pd.Play();
    }

    private IEnumerator ShowText()
    {
        showing = true;
        skipText.SetActive(true);
        yield return new WaitForSeconds(waitTimeText);
        showing = false;
        skipText.SetActive(false);
    }
}
