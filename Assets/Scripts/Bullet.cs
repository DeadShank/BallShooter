using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1;
    public Transform GatePos;
    public bool ReadyToShoot;
    public float explosionRadius;
    private void Update()
    {
        if (ReadyToShoot)
        {
            transform.position = Vector3.MoveTowards(transform.position, GatePos.position, speed * Time.deltaTime);
        }
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Gate") || other.gameObject.CompareTag("Pillar"))
        {
            Destroy(gameObject);
        }
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius + 0.5f);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Pillar"))
            {
                hit.GetComponent<MeshRenderer>().material.color = Color.yellow;
                Destroy(hit.gameObject, 1);
            }
        }
    }
    
    
}