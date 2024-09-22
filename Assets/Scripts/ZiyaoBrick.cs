using HelloMarioFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ZiyaoBrick : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    public ZiyaoQuestionBlock QuestionBrick; 
    private float check_time = 1f;
    private Coroutine exitCoroutine;
    private void Start()
    {

        videoPlayer.loopPointReached += OnVideoLoopPointReached;
    }
    private void OnCollisionExit(Collision collision)
    {
        Player p = collision.transform.GetComponent<Player>();
        if (p != null)
        {
            if (videoPlayer.isPlaying) {
                
                exitCoroutine = StartCoroutine(TriggerAfterTime(check_time));
            }
            
        }
    }
    IEnumerator TriggerAfterTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);  // Wait for the specified time 
        QuestionBrick.savedTime = videoPlayer.time;
        videoPlayer.Pause();
        videoPlayer.gameObject.SetActive(false);
        QuestionBrick.gameObject.SetActive(true);
        Debug.Log("Triggered after " + waitTime + " seconds from Collision Exit");
    }
    void OnVideoLoopPointReached(VideoPlayer vp)
    {
        QuestionBrick.savedTime = 0;  // Reset the savedTime when the video finishes a loop
        QuestionBrick.gameObject.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.transform.GetComponent<Player>();
        if (p != null)
        {
            if (exitCoroutine != null)
            {
                StopCoroutine(exitCoroutine);
                exitCoroutine = null;  // Reset the reference
            }
        }
    }

}
