using UnityEngine;

public class KontrolAbrirPuerta2 : MonoBehaviour
{
    [SerializeField] bool bIreki2 = true;
    public Animator Atea2Animator; // Controlador de animaciones para la rampa

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.name == "Prota")
        {
            Debug.Log("El jugador ha tocado el botón");

            if (collision.gameObject.name == "Prota")
            {
                Atea2Animator.GetComponent<Animator>().SetBool("bIreki2", true);
            }

        }
    }
}

