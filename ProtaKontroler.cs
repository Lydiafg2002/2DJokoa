using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ProtaKontroler : MonoBehaviour
{
    [SerializeField] float FMAXabiadura;
    [SerializeField] bool bEskumaraBegira;
    [SerializeField] float fSaltoIndarra;
    [SerializeField] float LurraTxekerRadius;
    [SerializeField] float fBalaIndarra;
    [SerializeField] float UkabilaRadius;
    [SerializeField] GameObject TextuPuntuak;
    [SerializeField] GameObject BizitzaK;
    [SerializeField] Transform resetPosition;

    GameObject LurraTxekerra;
    public Transform Ukabila;
    public GameObject BalaProta;

    public LayerMask ZerdaEtsaia;
    public LayerMask ZerDaLurra;
    public float fFrekuentziaDisparo = 1.0f;
    public float AzkenTiro = 0.0f;

    public int iBizitzak;
    int iPuntuazioa = 0;
    bool Hemanda = false;
    public bool bHilda = false;
    public float Rebote = 10f;
    public bool isUpArrowActive = false;

   float MogimenduVector;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Ukabila.transform.position, UkabilaRadius);
    }

    void Start()
    {
        LurraTxekerra = GameObject.Find("LurraTxeker");
        TextuPuntuak.SetActive(true);
    }

    void Update()
    {
        bool bLurrean = Physics2D.OverlapCircle(LurraTxekerra.transform.position, LurraTxekerRadius, ZerDaLurra);

        gameObject.GetComponent<Animator>().SetBool("bLurreanANI", bLurrean);

        //if (Input.GetKeyDown(KeyCode.Space) && bLurrean)
        //{
        //    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        //    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fSaltoIndarra);
        //    gameObject.GetComponent<Animator>().SetBool("bAirean", true);
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    isUpArrowActive = true;
        //}

        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    isUpArrowActive = false;
        //}

        if (Input.GetKeyDown(KeyCode.Q) && (AzkenTiro < Time.time))
        {
            if (isUpArrowActive)
            {
                AzkenTiro = Time.time + fFrekuentziaDisparo;
                gameObject.GetComponent<Animator>().SetBool("bTiroG", true);
                TiroGora();
                Invoke("TiroBukatu", 0.9f);
            }

        }

        if (Input.GetKeyDown(KeyCode.Q) && (AzkenTiro < Time.time))
        {
            AzkenTiro = Time.time + fFrekuentziaDisparo;
            gameObject.GetComponent<Animator>().SetBool("bTiro", true);
            TiroAurrera();
            Invoke("TiroBukatu", 0.9f);
        }

        

        if (Input.GetKeyDown(KeyCode.E) && (AzkenTiro < Time.time))
        {
            AzkenTiro = Time.time + fFrekuentziaDisparo;
            gameObject.GetComponent<Animator>().SetBool("bMelee", true);
            Ukabilkada();
            Invoke("TiroBukatu", 0.9f);
        }
    }

    //void FixedUpdate()
    //{
    //    float mogimendua = Input.GetAxis("Horizontal");
    //    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(mogimendua * FMAXabiadura * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    //    gameObject.GetComponent<Animator>().SetFloat("fAbiadura", Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x));

    //    if ((mogimendua < 0) && (bEskumaraBegira == true))
    //    {
    //        Flipeatu();
    //    }

    //    if ((mogimendua > 0) && (bEskumaraBegira == false))
    //    {
    //        Flipeatu();
    //    }
    //}

    public void Mogimendu(InputAction.CallbackContext context)
    {
        MogimenduVector = context.ReadValue<Vector2>().x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataforma"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * Rebote;
            }
        }
    }

    void Flipeatu()
    {
        bEskumaraBegira = !bEskumaraBegira;
        Vector2 nireeskala = gameObject.transform.localScale;
        nireeskala.x = -nireeskala.x;
        gameObject.transform.localScale = nireeskala;
    }

    void TiroAurrera()
    {
        GameObject Klona = GameObject.Instantiate(BalaProta, gameObject.transform.Find("BazokaPuntaP").transform.position, gameObject.transform.Find("BazokaPuntaP").transform.rotation);
        Klona.name = "BalaProta";
        if (bEskumaraBegira)
        {
            Klona.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fBalaIndarra);
        }
        else
        {
            Klona.GetComponent<Rigidbody2D>().AddForce(Vector2.left * fBalaIndarra);
        }
        Destroy(Klona, 3.0f);
    }

    void TiroGora()
    {
        GameObject Klona = GameObject.Instantiate(BalaProta, gameObject.transform.Find("BazokaPuntaG").transform.position, gameObject.transform.Find("BazokaPuntaG").transform.rotation);
        Klona.name = "BalaProta";
        Klona.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fBalaIndarra);
        Klona.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        Destroy(Klona, 3.0f);
    }

    void Ukabilkada()
    {
        Collider2D[] Kolpe = Physics2D.OverlapCircleAll(transform.position, UkabilaRadius, ZerdaEtsaia);

        foreach (Collider2D etsaia in Kolpe)
        {
          etsaia.gameObject.GetComponent<EtsaiLurrean1Kontroler>().EtsaiariHit();
        }
    }

    public void TiroBukatu()
    {
        gameObject.GetComponent<Animator>().SetBool("bTiro", false);
        gameObject.GetComponent<Animator>().SetBool("bTiroG", false);
        gameObject.GetComponent<Animator>().SetBool("bMelee", false);
    }

    public void ProtariHit()
    {
        if (!Hemanda) 
        {
            iBizitzak -= 1;
            kenduBizitzak(1);
            if (iBizitzak <= 0)
            {
                bHilda = true;
                Invoke("Bukatu", 1);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("die");
                gameObject.transform.position = resetPosition.position;
            }
        }
    }

    public void puntuakgehitu(int zenbatPuntu)
    {
        iPuntuazioa = iPuntuazioa + zenbatPuntu;
        puntuazioAldatu(iPuntuazioa);
    }

    private void kenduPuntuazioa(int zenbatPuntu)
    {
        iPuntuazioa = iPuntuazioa - zenbatPuntu;
        if (iPuntuazioa < 0)
        {
            iPuntuazioa = 0;
        }
        puntuazioAldatu(iPuntuazioa);
    }

    private void kenduBizitzak(int zenbatBizitza)
    {
        iBizitzak = iBizitzak - zenbatBizitza;
        if (iBizitzak < 0)
        {
            iBizitzak = 0;
        }
        BizitzaAldatu();
    }

    void puntuazioAldatu(int puntuazioa)
    {
        PlayerPrefs.SetInt("puntuazioa", puntuazioa);
        TextuPuntuak.GetComponent<TMP_Text>().text = "" + iPuntuazioa;
    }
    void BizitzaAldatu()
    {
        BizitzaK.GetComponent<TMP_Text>().text = "X " + iBizitzak;
    }

    void Bukatu()
    {
        SceneManager.LoadScene("GameOver");
    }

}
