using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    //Esto crea un arreglo de enemigos.
    private void OnEnable()
  {
        _enemies = FindObjectsOfType<Enemy>();
  }
    void Update()
    {
        //Esta seccion cuenta todos los enemigos, si detecta que no hay enemigos pasamos al siguiente nivel.
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        // Esto nos muestra cuando todos los enemigos fueron derrotados.
        Debug.Log("You killed all enemies");
        // Estp nos muestra el nivel al que pasamos.
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
