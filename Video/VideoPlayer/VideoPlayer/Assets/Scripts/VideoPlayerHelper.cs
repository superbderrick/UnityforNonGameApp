using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHelper : MonoBehaviour
{
    public RawImage videoScreen;
    public VideoClip videoClip;

    public Button playOrPauseButton;
    
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private void Awake()
    {
        SetupVideoPlayer();
    }

    private void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnPrepareCompleted;
    }


    private void SetupVideoPlayer()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false; 
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;
        
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted  += OnPrepareCompleted;
    }

    private void OnPrepareCompleted(VideoPlayer source)
    {
        videoScreen.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    public void PlayorPause()
    {
        if (videoPlayer.isPrepared)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                
                
            }
            else
            {
                videoPlayer.Play();
            }
        }
        else
        {
            Debug.Log("Video Player is not prepared yet");
        }
    }
    
}
