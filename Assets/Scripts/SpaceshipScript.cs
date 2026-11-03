using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float force;

    private float minX = -7.5f;
    private float maxX = 7.5f;

    private float horizontalMovement;
    Rigidbody2D rb;

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

    }

    private void FixedUpdate()
    {
        //Movimiento horizontal de la nave.
        rb.AddForce(Vector3.right * force * horizontalMovement, ForceMode2D.Force);
    }
}
