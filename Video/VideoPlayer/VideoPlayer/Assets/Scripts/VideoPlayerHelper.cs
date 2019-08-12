using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHelper : MonoBehaviour
{
    public RawImage videoScreen;
    public VideoClip videoClip;

    private Button playButton , stopButton;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private void Awake()
    {
        SetupVideoPlayer();        
    }

    private void Start()
    {
        setupButtons();
    }

    private void setupButtons()
    {
        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>(); 
        Button stopButton = GameObject.Find("StopButton").GetComponent<Button>();
        
        playButton.onClick.AddListener(PlayVideo);
        stopButton.onClick.AddListener(StopVideo);
    }

   
    private void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnPrepareCompleted;
    }


    private void SetupVideoPlayer()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = true; 
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;
        
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted  += OnPrepareCompleted;
    }

    private void OnPrepareCompleted(VideoPlayer source)
    {
        videoScreen.texture = videoPlayer.texture;
    }

    public void PlayVideo()
    {
        if (videoPlayer.isPrepared)
        {
            videoPlayer.Play();
        }
        
    }

    public void StopVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
        
    }
    
}
