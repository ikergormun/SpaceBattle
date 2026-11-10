using UnityEngine;

public class Enemy01Script : MonoBehaviour
{
    [SerializeField] private float force = 1;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.down * force, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detectamos si la nave enemiga detecta una bala que ha disparado nuestra nave.

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
