using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Entry Entry;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject bulletPrefab;

    public bool GoToFinish;

    private float minSize = 0.1f;
    private float maxTime = 6;
    private float currentTime;
    private float initialScale;
    private float speed = 3f;
    private GameObject currentBullet;

    private void OnValidate()
    {
        initialScale = transform.localScale.x;
    }

    private void OnMouseDown()
    {
        currentBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
    }

    private void OnMouseDrag()
    {
        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            float scaleFactor = currentTime / maxTime;

            float newScale = Mathf.Max(minSize, initialScale - (initialScale * scaleFactor));
            transform.localScale = Vector3.one * newScale;
            currentBullet.GetComponent<Bullet>().explosionRadius = currentBullet.transform.localScale.x * scaleFactor;

            if (currentBullet != null)
            {
                currentBullet.transform.localScale = Vector3.one * (scaleFactor + 0.1f);
            }
        }

        if (transform.localScale.x <= minSize)
        {
            Entry.UIController.EnableLoseScreen();
            enabled = false;
        }
    }

    private void OnMouseUp()
    {
        if (currentBullet != null)
        {
            currentBullet.GetComponent<Bullet>().UnlockMovement = true;

            initialScale = transform.localScale.x;

            currentTime = 0f;
            currentBullet = null;
        }
    }

    private void Update()
    {
        if (GoToFinish)
        {
            MovePlayerToNextPoint();
        }
    }

    public void MovePlayerToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, Entry.Gate.gameObject.transform.position,
            speed * Time.deltaTime);
    }
}