using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TecnologiaSocialControler : Menu
{
    public Text tituloTecnologia;
    public GameObject areaConfirmaRAButton; 
    
    // Start is called before the first frame update
    public void Start()
    {
        tituloTecnologia.text = StateControler.tituloTecnologiaSocial;
        //confirmaRAButton = GameObject.Find("ConfirmacaoPoliticaRA").GetComponent<Button>();
    }

    public void LoadSceneConhecaTecnologia()
    {
        Debug.Log("StateControler.tecnologiaSocia:"+ StateControler.tecnologiaSocial);
        switch (StateControler.tecnologiaSocial)
        {
            case "fogaoSolar":
                StateControler.descricaoTecnologiaSocial = LangResolver.loadText("descricao_tecnologia_social_fogao_solar").Replace("\\n", "\n");
                /*"Consiste em captar os raios solares e converter a irradiação solar em calor " +
                "para o cozimento de alimentos. Aqui utilizaremos uma antena parabólica antiga coberta por papel alumínio para melhorar " +
                "a reflexão do sol e centralizar a energia em um ponto convergente." +
                "\n\n" +
                "É montada uma base de ferro onde será pendurada a panela em um ângulo que receba o calor gerado pela reflexão" +
                " dos raios solares." +
                "\n\n" +
                "Energia limpa sem a emissão de gases poluentes, uma iniciativa que pode ser bastante aproveitada em regiões de " +
                "grande abundância de sol. ";*/
                break;
            case "dessanilizadorSolar": 
                StateControler.descricaoTecnologiaSocial = LangResolver.loadText("descricao_tecnologia_social_dessanilizador").Replace("\\n", "\n");
                /*"Consiste em transformar água salobra em água potável, para isso é "+
                "utilizado um sistema para captar a água em placas pré-moldadas de concreto com uma cobertura de vidro o qual "+
                "permite a passagem da radiação solar (ondas curtas) mas inibe a saída das ondas longas."+ 
                "\n\n"+
                "No piso da estrutura é colocada uma lona, para quando a irradiação do sol aumente a temperatura e provoque a "+
                "evaporação da água e possa recolher o sal."+ 
                "\n\n"+
                "Quando a água evapora e acaba se condensando no paredes do vidros, que irão conter um ângulo em torno de 45º "+
                "para que a água vá deslizando e para que seja escoado por uma tubulação, onde será armazenada e estará pronta para o "+
                "consumo."+
                "\n\n"+
                "Essa tecnologia não é necessariamente apenas para o consumo de pessoas, mas também para animais que muitas "+
                "vezes recusam a água com alto teor de salobridade, que é a incidência de sal na água.";*/
                break;
                /*default:
                    SceneManager.LoadScene(indexScene);
                    break;*/
        }
        SceneManager.LoadScene("ConhecaTecnologia");
        //SceneManager.LoadSceneAsync(indexScene);
    }

    public void LoadSceneMateriaisNecessarios()
    {
        //Debug.Log("StateControler.tecnologiaSocia:" + StateControler.tecnologiaSocial);
        switch (StateControler.tecnologiaSocial)
        {
            case "fogaoSolar":
                SceneManager.LoadScene("MateriaisNecessariosFogaoSolar");
                break;
            case "dessanilizadorSolar":
                SceneManager.LoadScene("MateriaisNecessariosDessalinizador");
                break;
        }
     
    }

    public void LoadSceneComoConstruir()
    {
        //Debug.Log("StateControler.tecnologiaSocia:" + StateControler.tecnologiaSocial);
        switch (StateControler.tecnologiaSocial)
        {
            case "fogaoSolar":
                SceneManager.LoadScene("ComoConstruirFogaoSolar");
                break;
            case "dessanilizadorSolar":
                SceneManager.LoadScene("ComoConstruirDessanilizador");
                break;
        }
        

    }

    public void LoadSceneAprendendo()
    {
        Debug.Log("StateControler.tecnologiaSocia:" + StateControler.tecnologiaSocial);
        switch (StateControler.tecnologiaSocial)
        {
            case "fogaoSolar":
                SceneManager.LoadScene("AR_FogaoSolar"); 
                break;
            case "dessanilizadorSolar":
                SceneManager.LoadScene("AR_FogaoSolar");
                //SceneManager.LoadScene("Aprendendo");
                break;
        }

    }

    // Update is called once per frame

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
