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
                /*"Consiste em captar os raios solares e converter a irradia��o solar em calor " +
                "para o cozimento de alimentos. Aqui utilizaremos uma antena parab�lica antiga coberta por papel alum�nio para melhorar " +
                "a reflex�o do sol e centralizar a energia em um ponto convergente." +
                "\n\n" +
                "� montada uma base de ferro onde ser� pendurada a panela em um �ngulo que receba o calor gerado pela reflex�o" +
                " dos raios solares." +
                "\n\n" +
                "Energia limpa sem a emiss�o de gases poluentes, uma iniciativa que pode ser bastante aproveitada em regi�es de " +
                "grande abund�ncia de sol. ";*/
                break;
            case "dessanilizadorSolar": 
                StateControler.descricaoTecnologiaSocial = LangResolver.loadText("descricao_tecnologia_social_dessanilizador").Replace("\\n", "\n");
                /*"Consiste em transformar �gua salobra em �gua pot�vel, para isso � "+
                "utilizado um sistema para captar a �gua em placas pr�-moldadas de concreto com uma cobertura de vidro o qual "+
                "permite a passagem da radia��o solar (ondas curtas) mas inibe a sa�da das ondas longas."+ 
                "\n\n"+
                "No piso da estrutura � colocada uma lona, para quando a irradia��o do sol aumente a temperatura e provoque a "+
                "evapora��o da �gua e possa recolher o sal."+ 
                "\n\n"+
                "Quando a �gua evapora e acaba se condensando no paredes do vidros, que ir�o conter um �ngulo em torno de 45� "+
                "para que a �gua v� deslizando e para que seja escoado por uma tubula��o, onde ser� armazenada e estar� pronta para o "+
                "consumo."+
                "\n\n"+
                "Essa tecnologia n�o � necessariamente apenas para o consumo de pessoas, mas tamb�m para animais que muitas "+
                "vezes recusam a �gua com alto teor de salobridade, que � a incid�ncia de sal na �gua.";*/
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
