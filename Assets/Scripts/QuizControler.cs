using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizControler : MonoBehaviour
{
    private Image botao1;
    private Image botao2;
    private Image botao3;
    private Image botao4;

    public SpriteRenderer errado;
    public SpriteRenderer certo;
    public GameObject areaBotao;

    private Color32 corCerta = new Color32(53, 255, 13, 255);
    private Color32 corErrada = new Color32(255, 13, 15, 255);
    private Color32 corDefault = new Color32(13, 226, 255, 255);


    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public Transform cam;
    public GameObject areaConfirmaRAButton;

    //Camera m_MainCamera;
    //CameraMovement myAccess;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Botao1") != null)
        {
            botao1 = GameObject.Find("Botao1").GetComponent<Image>();
            botao2 = GameObject.Find("Botao2").GetComponent<Image>();
            botao3 = GameObject.Find("Botao3").GetComponent<Image>();
            botao4 = GameObject.Find("Botao4").GetComponent<Image>();
        }

        if(errado != null)
        {
            errado.enabled = false;
        }
        if (certo != null)
        {
            certo.enabled = false;
        }
        if(areaBotao != null)
        {
            areaBotao.SetActive(false);
        }

        //errado = GameObject.Find("Errado").GetComponent<SpriteRenderer>();
        //myAccess = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        //m_MainCamera = Camera.main;
        //m_MainCamera.
        //ScriptableObject teste = m_MainCamera.GetComponent<ScriptableObject>();
        //Debug.Log("Script:"+teste);
    }

    public void Resposta(string botao)
    {
        //Debug.Log("LoadSceneVar" + indexScene);
        /*
        switch (indexScene)
        {

            case "errada":
                Debug.Log("ERRADO");
                botao1.color = corErrada;
                //SceneManager.LoadScene("TecnologiaSocial");
                break;
            case "certa":
                Debug.Log("CERTO");
                botao1.color = corCerta;
                //SceneManager.LoadScene("TecnologiaSocial");
                break;
        }
        */

        switch (botao)
        {

            case "botao1":
                botao1.color = corErrada;
                errado.enabled = true;
                start = true;
                break;
            case "botao2":
                botao2.color = corErrada;
                errado.enabled = true;
                start = true;
                break;
            case "botao3":
                botao3.color = corCerta;
                certo.enabled = true;
                StartCoroutine(showNext());
                break;
            case "botao4":
                botao4.color = corErrada;
                errado.enabled = true;
                start = true;
                break;
                /*default:
                    SceneManager.LoadScene(indexScene);
                    break;*/
        }

        //SceneManager.LoadSceneAsync(indexScene);
    }

    public void RespostaII(string botao)
    {
        switch (botao)
        {

            case "botao1":
                botao1.color = corErrada;
                errado.enabled = true;
                start = true;
                break;
            case "botao2":
                botao2.color = corCerta;
                certo.enabled = true;
                StartCoroutine(showNext());
                break;
            case "botao3":
                botao3.color = corErrada;
                errado.enabled = true;
                start = true; 
                break;
            case "botao4":
                botao4.color = corErrada;
                errado.enabled = true;
                start = true;
                break;
                /*default:
                    SceneManager.LoadScene(indexScene);
                    break;*/
        }

    }

    void botoesDefault()
    {
        botao1.color = corDefault;
        botao2.color = corDefault;
        botao3.color = corDefault;
        botao4.color = corDefault;
        errado.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Debug.Log("Update()");
            start = false;
            StartCoroutine(Shaking());
        }
    }

    public IEnumerator Shaking()
    {
        areaBotao.SetActive(false);
        Vector3 startPosition = cam.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            cam.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        cam.position = startPosition;
        botoesDefault();
    }

    public IEnumerator showNext()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        certo.enabled = false;
        areaBotao.SetActive(true);
    }

    public void GoBack()
    {
        //Debug.Log("ConhecaTecnologiaControler.GoBack()");
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("Menu");

    }

    public void GoBackQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void GoScene(string tela)
    {
        SceneManager.LoadScene(tela);
    }

    public void GoSpiderRA()
    {
        StateControler.tecnologiaSocial = "ar_spider";
        SceneManager.LoadScene("AR_Spider");
    }

    public void ConfirmaPoliticaRA(string acao)
    {
        switch (acao)
        {

            case "ok":
                //botao1.color = corErrada;
                areaConfirmaRAButton.SetActive(true);
                //start = true;
                break;
            case "voltar":
                //botao2.color = corErrada;
                areaConfirmaRAButton.SetActive(false);
                break;
        }

        //SceneManager.LoadSceneAsync(indexScene);
    }

}
