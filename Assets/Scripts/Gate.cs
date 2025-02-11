using System;
using DG.Tweening;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] public Entry Entry;
        
    [SerializeField] private Transform door;
    [SerializeField] private Player player;

    private float openDistance = 2f;
    private float duration = 0.5f;
    private bool isOpen;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Entry.UIController.EnableWinScreen();
            player.enabled = false;
        }
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            OpenDoors();
            isOpen = true;
        }
    }

    private void OpenDoors()
    {
        if (isOpen) return;
        door.DOMoveY(door.localPosition.y + openDistance, duration);
        player.GoToFinish = true;
    }
}