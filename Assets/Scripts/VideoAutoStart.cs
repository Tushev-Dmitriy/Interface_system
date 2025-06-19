using UnityEngine;
using UnityEngine.Video;

public class VideoAutoStart : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;

    private void Awake()
    {
        player.Prepare();
        player.prepareCompleted += OnPrepared;
    }

    private void OnPrepared(VideoPlayer vp)
    {
        vp.Play();
    }
}
