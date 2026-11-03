using UnityEngine;
using TMPro;

public class AguilaController : MonoBehaviour
{
    public float velocidad = 5f;
    public TMP_Text textoPuntaje;

    private int puntaje = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        ActualizarPuntaje();
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.W)) y = 1f;
        if (Input.GetKey(KeyCode.S)) y = -1f;
        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;

        direccion = new Vector2(x, y).normalized;

        if (x > 0)
            sprite.flipX = true;

        if (x < 0)
            sprite.flipX = false;
    }

    void FixedUpdate()
    {
        rb.velocity = direccion * velocidad;
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Gema"))
        {
            puntaje += 10;
            Destroy(otro.gameObject);
            ActualizarPuntaje();
        }
        else if (otro.CompareTag("Cereza"))
        {
            puntaje -= 5;
            Destroy(otro.gameObject);
            ActualizarPuntaje();
        }
    }

    void ActualizarPuntaje()
    {
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntaje: " + puntaje;
    }
}