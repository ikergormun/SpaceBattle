using UnityEngine;

public class MachineGunScript : MonoBehaviour
{
    [SerializeField] private float force = 2;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cojo el componente RB de la bala.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Movimiento de la bala con RB hacia arriba.
        rb.AddForce(Vector3.up * force, ForceMode2D.Force);
    }
}
