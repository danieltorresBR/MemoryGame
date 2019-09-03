using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Crosstales.RTVoice;
using Crosstales.RTVoice.Model;

public class SpeekE : MonoBehaviour{
    
    public AudioSource som;            // Audio da Voz
    private Animator anim;             // Controle da animação
    public GameObject ballonImage;     // Imagem do balão
    public Text textBallon;            // Texto no balão
    private string animState;          // Guarda a animação atual
    Frase estadoAtual = new Frase();
    Arquivos ctrArq;

    void Start(){
        anim = GetComponent<Animator>();   // Pegando a Animator para controle das animações
        ballonImage.SetActive(false);      // esconde a imagem do balão

        ctrArq = new Arquivos("1");
        estadoAtual = ctrArq.getFrases("7");
        Debug.Log(estadoAtual.msg);
        print(ctrArq.filePath);

        setConf(estadoAtual);   
    }

    public void Speek(){
        // Quando essa função é chamada o TextToSpeech falará a frase contidade em estadoAtual.msg

        //Speaker.Speak(text.text, null, Speaker.VoiceForName("Microsoft Daniel"));
        Speaker.Speak(estadoAtual.msg, som, Speaker.VoiceForName("Microsoft Daniel"));
        ctrArq.registra(estadoAtual.msg, estadoAtual.codigo, estadoAtual.emocao);
    }

    void Update(){
        
        // Controle da animação
        animCtr();

    }

    public void setPassivo(){
        anim.SetBool(animState, false);
        anim.SetBool("Passivo_1", true);
    }

    public void startAnimation(){
        anim.SetBool(animState, true);
        anim.SetBool("Passivo_1", false);
    }

    private void animCtr(){
        /*
            Essa função é responsavel por detectar a voz do agente e ativa a animação correspondente.
            Responsavel também por ativar o balão com a menssagem do Agente.
        */

        if(som.isPlaying == true){
            //anim.SetBool(animState, true);
            //anim.SetBool("Passivo_1", false);
            ballonImage.SetActive(true);
        }
        if(som.isPlaying == false){
            //anim.SetBool(animState, false);
            //anim.SetBool("Passivo_1", true);
            ballonImage.SetActive(false);
        }
    }

    private void setConf(Frase frase){
        /*
            Essa função é responsavel por receber um objeto frase e setar a frase no balão, na voz do robo e definir a animação
        */
        
        textBallon.text = frase.msg;
        animState = frase.emocao;
        
    }

    public void reacao(int sentimento){
        /*
            Função receber um sentimento e escolhe aleatoriamente uma frase no banco de frases com o sentimento correspondente
        */

        if(sentimento == 1){
            estadoAtual = ctrArq.getFrases("5");
            Debug.Log(estadoAtual.msg);

            setConf(estadoAtual);

            startAnimation();
        }
        if(sentimento == 2){
            estadoAtual = ctrArq.getFrases("6");
            Debug.Log(estadoAtual.msg);

            setConf(estadoAtual);

            startAnimation();
        }
    }
}
