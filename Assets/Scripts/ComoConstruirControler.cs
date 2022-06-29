using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ComoConstruirControler : MonoBehaviour
{
    public Text tituloTecnologia;
    [SerializeField]
    public VideoPlayer videoPlayer;
    public VideoClip videoClipPrimeiraParte;
    public VideoClip videoClipSegundaParte;
    //public Text descricaoTecnologia;
    private GameObject botaoIniciarMontagem;
    private Text descMontagem;
    private bool primeiroVideo = true;

    // Start is called before the first frame update
    public void Start()
    {
        tituloTecnologia.text = StateControler.tituloTecnologiaSocial;
        //descricaoTecnologia.text = StateControler.descricaoTecnologiaSocial;
        Screen.orientation = ScreenOrientation.Landscape;
        Debug.Log("ScreenOrientation.Landscape");

        botaoIniciarMontagem = GameObject.Find("AreaBotaoMontagem");
        descMontagem = GameObject.Find("DescMontagemBotao").GetComponent<Text>();
        descMontagem.text = LangResolver.loadText("iniciar_montagem"); //"Iniciar Montagem";

        ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("videoPlayer.frameCount:"+ videoPlayer.frameCount);
        //Debug.Log("videoPlayer.frame:" + videoPlayer.frame);
        if (((long)videoPlayer.frameCount) == (videoPlayer.frame + 1))
        {
            if (primeiroVideo) { 
                Debug.Log("Fim do Vídeo");
                videoPlayer.clip = videoClipSegundaParte;
                descMontagem.text = LangResolver.loadText("demonstrar_funcionamento"); //"Demonstrar Funcionamento";
                botaoIniciarMontagem.SetActive(true);
                primeiroVideo = false;
            }
            else
            {
                descMontagem.text = LangResolver.loadText("rever_demonstracao");  //"Rever Demonstração";
                botaoIniciarMontagem.SetActive(true);
                videoPlayer.clip = videoClipPrimeiraParte;
                primeiroVideo = true;
            }
        }

    }

    public void GoBack()
    {
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("TecnologiaSocial");
        Debug.Log("GoBack()");
    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.TranslucentOverContent;
    }


    public void play()
    {
        videoPlayer.Play();
        botaoIniciarMontagem.SetActive(false);
    }
}
