using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Berd Berd = collision.collider.GetComponent<Berd>();
        if (Berd != null)
        {
            Instantiate(_cloudParticlePrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy Enemy = collision.collider.GetComponent<Enemy>();
        if (Enemy !=null)
        { 
            return;
        }

       if( collision.contacts[0].normal.y < - 0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }

     }
}
