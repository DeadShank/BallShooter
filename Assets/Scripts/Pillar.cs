using UnityEngine;

public class Pillar : MonoBehaviour
{
    private float time = 1;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            
            Destroy(gameObject, time);
        }
    }
}