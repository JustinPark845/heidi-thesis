using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Tutorial : MonoBehaviour
{
    public PlayableDirector timeline;
    public string newSceneName;

    void Start()
    {
        timeline.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        SceneManager.LoadScene("GamePlay");
    }
}