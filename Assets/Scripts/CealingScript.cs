using UnityEngine;

public class CealingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo que se activa cuando un trigger entra en Cealing.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detectamos si es una bala

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
