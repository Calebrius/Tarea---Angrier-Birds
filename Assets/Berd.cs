using UnityEngine;
using UnityEngine.SceneManagement;

public class Berd : MonoBehaviour
{
    //Esta seccion declara las variables globales.
    private Vector3 _initialPosition;
    private bool _berdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }
    //Cambiar el Color del pajarito cuando mantengo el boton sobre el.
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void Update()
    {
        //Esta seccion dibuja las flechas que marcan desde donde se esta tirando el pajarito.
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        //Esto establece los limites hasta donde llega el pajarito antes de reiniciarse.
        if (_berdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        
        if (transform.position.y > 20  ||
            transform.position.y < -20 ||
            transform.position.x > 20 ||
            transform.position.x < -20||
            _timeSittingAround > 3)
        {
            //Reinicio de escena si pierde.
            string currentsceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentsceneName);
        }        
    }

    //Este metodo controla el movimiento del pajartio despues de que se lanza
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent <Rigidbody2D>().gravityScale = 1;
        _berdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    //Este metodo mueve al pajarito desde el punto de inicio hasta donde se quiera estirar para lanzarlo.
    private void OnMouseDrag()
    {
        Vector3 newposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newposition.x, newposition.y);
    }
}
