using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    //Este metodo establece la forma de eliminar a los enemigos.
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

        //Estas son las particulas de los enemigos cuando mueren
       if( collision.contacts[0].normal.y < - 0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }

     }
}
