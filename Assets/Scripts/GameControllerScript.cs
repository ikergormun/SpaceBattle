using System.Collections;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy_01Prefab;
    [SerializeField] float Enemy_01Cooldown;

    IEnumerator GenerarEnemies()
    {
        yield return new WaitForSeconds(Enemy_01Cooldown);
        //Instancio las naves enemigas
        GameObject newEnemy_01 = Instantiate(Enemy_01Prefab);

        //La nave spawnea en una posicion aleatoria en los limites del escenario
        newEnemy_01.transform.position = new Vector3(Random.Range(-7f, 7f), 8.5f);
        //Vuelvo a llamar a la corrutina en la propia corrutina para que siga spawneando naves enemigas.
        StartCoroutine(nameof(GenerarEnemies));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(GenerarEnemies));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
