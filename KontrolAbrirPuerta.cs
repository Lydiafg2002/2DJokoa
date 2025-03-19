using UnityEngine;

public class KontrolAbrirPuerta : MonoBehaviour
{
    [SerializeField] bool bIreki = true;
    public Animator AteaAnimator; // Controlador de animaciones para la rampa

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.name == "Prota")
        {
            Debug.Log("El jugador ha tocado el botón");

            if (collision.gameObject.name == "Prota")
            {
                AteaAnimator.GetComponent<Animator>().SetBool("bIreki", true);
            }
           
        }
    }
}



