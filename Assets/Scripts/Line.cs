using System;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] public Entry Entry;

    private Vector3 defaultScale;

    private float ScalePlayerBall => Entry.Player.gameObject.transform.localScale.x;

    private void Start()
    {
        defaultScale = gameObject.transform.localScale;
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(ScalePlayerBall, defaultScale.y, defaultScale.z);
        
    }
}
