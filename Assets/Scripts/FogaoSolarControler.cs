using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FogaoSolarControler : MonoBehaviour
{

    private Text recomendacao;
    private Image pinch;
    private GameObject recomendacaoScaleRotation;
    private GameObject recomendacaoInformativo;
    public Text tituloTecnologia;

    // Start is called before the first frame update
    void Start()
    {
        //recomendacao = GameObject.Find("Recomendacao").GetComponent<Text>();
        //recomendacao.text = ""; //"Clique na tela para incluir o objeto"
        //"Posicione a camera em superfice plana até aparecer o marcardor"

        //pinch = GameObject.Find("PinchAnimation").GetComponent<Image>();
        //pinch.enabled = false;


        tituloTecnologia.text = StateControler.tituloTecnologiaSocial;
        recomendacaoScaleRotation = GameObject.Find("RecomendacaoScaleRotation");
        //recomendacaoScaleRotation.SetActive(false);
        recomendacaoInformativo = GameObject.Find("RecomendacaoInformativo");
        //recomendacaoInformativo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoBack()
    {
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("Menu");

    }
}
