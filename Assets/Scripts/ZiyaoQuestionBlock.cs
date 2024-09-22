using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using HelloMarioFramework;
public class ZiyaoQuestionBlock : QuestionBlock
{
    [SerializeField]
    private AudioClip CoinSound;

    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    GameObject QuestionBrick_obj;
    public double savedTime = 0;
    protected override void Start()
    {
        animator = transform.GetComponent<Animator>();
        audioPlayer = gameObject.AddComponent<AudioSource>();
        audioPlayer.volume = 0.1f;
    }
    protected override void BlockHit()
    {
        Debug.Log("Block hit");
        audioPlayer.PlayOneShot(CoinSound);
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.time = savedTime;
        videoPlayer.Play();
        QuestionBrick_obj.SetActive(false);
    }
    


    void Update()
    {
        
    }
}
