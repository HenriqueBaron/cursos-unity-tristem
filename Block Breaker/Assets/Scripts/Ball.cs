using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private static bool hasStarted;

    // Use this for initialization
    void Start()
    {
        hasStarted = false;
        /* O método FindObjectOfType<T>() busca na cena por um objeto do tipo especificado. Neste caso, deseja-se
         * conectar a bola programaticamente à raquete (paddle) ao inicializar a cena. Isso é utilizado porque tanto 
         * a bola como a raquete são prefabs (templates de GameObject), mas não é possível estabelecer uma conexão
         * entre as referências dos prefabs ao criá-los. Isso precisa ser feito programaticamente. */
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
