using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {

    public Material[] videoMats;
    public RenderTexture[] videoTextures;
    public Renderer videoObject;
    public Animator cameraAnim;
    private VideoPlayer[] players;

    private bool _animate;

	// Use this for initialization
	void Start () {

        players = GetComponentsInChildren<VideoPlayer>();
        for (var i = 1; i < players.Length; i++)
            players[i].gameObject.SetActive(false);

	}

    private void Update()
    {
        if (_animate)
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, 100, 1 * Time.deltaTime);
    }

    public void NextVideo()
    {
        players[0].gameObject.SetActive(false);
        players[1].gameObject.SetActive(true);
        //RenderSettings.skybox = videoMats[1];
        videoObject.material.mainTexture = videoTextures[1];
        videoObject.gameObject.GetComponent<Animation>().Play();

    }
}
