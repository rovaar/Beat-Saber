using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeExplode : MonoBehaviour
{

    public GameObject shatteredObject;
    public GameObject mainCube;
    private GameObject sceneManager;
    private ScoreManager scoreManager;
    private bool shooted;
    // Start is called before the first frame update
    void Start()
    {
       //TODO: activar el cub normal (mainCube) i desactivar el cub d'explosió (shatteredObject)
       shatteredObject.SetActive(false);
        mainCube.SetActive(true);
        sceneManager = GameObject.FindGameObjectWithTag("scoreManager");
        scoreManager = sceneManager.GetComponent<ScoreManager>();
        shooted = false;
    }
    private void Kill()
    {
        Destroy(gameObject);
    }
    public void IsShot()
    {
        //TODO:
        //Si el cub ha sigut impactat per una bala -->
        //-Destruir el mainCube
        //-Activar el shatteredObject 
        //-Fer play en el component Animation del shatteredObject
        //-Destruir el shatteredObject després de 1 segon.
        if (shooted == false)
        {
            shooted = true;
            mainCube.SetActive(false);
            shatteredObject.SetActive(true);
            scoreManager.AddScore(2);
            Invoke("Kill", 1.0f);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        //TODO:
        //-Si l'objecte que ha entrat en el trigger del cub té tag "Bullet"
        //   aleshores activar la funció IsShot
        if (other.gameObject.CompareTag("Bullet")){
            IsShot();
        }
    }


}
