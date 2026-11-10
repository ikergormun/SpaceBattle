using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float force;

    private float minX = -7.5f;
    private float maxX = 7.5f;

    private float horizontalMovement;
    Rigidbody2D rb;

    //Prefab de la bala.
    [SerializeField] GameObject newBulletPrefab;
    [SerializeField] float BulletCooldown = 1f;

    //Booleano para permitir disparar o no.
    private bool CanShoot = true;

    //Corrutina de Cooldown
    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(BulletCooldown);
        CanShoot = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento Horizontal de la nave con RigidBody. Variable horizontalMovement
        horizontalMovement = Input.GetAxis("Horizontal");

        //Límite de la pantalla con Mathf.Clamp
        Vector3 clampedPosition = transform.position; //Guardo la posicion de la nave en una variable temporal clampedPosition.
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX); //Cojo la coordenada "X" de la variable temporal clampedPosition y le aplico Mathf.Clamp con minX y maxX.
        transform.position = clampedPosition; //Aplico los cambios hechos en la variable clampPosition al transform de la nave.

        //Al pulsar la tecla E la nave spawnea balas con un cooldown.
        if (Input.GetKey(KeyCode.E) && CanShoot)
        {
            //Creo una nueva bala con el Prefab de la bala
            GameObject newBullet = Instantiate(newBulletPrefab); //Instancio una nueva bala
            newBullet.transform.position = transform.position; //Transformo la posicion de la bala y le asigno la posicion de la nave.
            CanShoot = false; //La booleana shoot la convierto false para que no puedas disparar hasta hacer la corrutina.

            //Llamar a la corrutina que volverá a activar el disparo.
            StartCoroutine(EnableShoot());
        }

    }

    private void FixedUpdate()
    {
        //Movimiento horizontal de la nave.
        rb.AddForce(Vector3.right * force * horizontalMovement, ForceMode2D.Force);
    }
}
