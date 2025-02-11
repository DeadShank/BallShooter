using System;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Player player;

    private Vector3 defaultScale;

    private float ScalePlayerBall => player.gameObject.transform.localScale.x;

    private void Start()
    {
        defaultScale = gameObject.transform.localScale;
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(ScalePlayerBall, defaultScale.y, defaultScale.z);
        
    }
}
