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
    Frase estadoAtual = new Frase();   // Objeto estado
    Arquivos ctrArq;                   // Objeto para acesso a L/E nos arquivos
    public int[] tabuleiro;
    int dica1, dica2;

    void Start(){
        anim = GetComponent<Animator>();   // Pegando a Animator para controle das animações
        ballonImage.SetActive(false);      // esconde a imagem do balão
        som = GetComponent<AudioSource>();

        ctrArq = new Arquivos("1");        // Criando novo arquivo com ID informado
        print(ctrArq.filePath);
    }

    public void Speek(){
        // Quando essa função é chamada o TextToSpeech falará a frase contidade em estadoAtual.msg

        //Speaker.Speak(text.text, null, Speaker.VoiceForName("Microsoft Daniel"));
        Speaker.Speak(estadoAtual.msg, som, Speaker.VoiceForName("Microsoft Daniel"));
        ctrArq.registra(estadoAtual.msg, estadoAtual.codigo, estadoAtual.emocao);
    }

    void Update(){
        
        // Controle da animação
        animCtr();  // Ativando balão de animação
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
            Responsavel por ativar o balão com a menssagem do Agente.
        */

        if(som.isPlaying == true){
            ballonImage.SetActive(true);
        }
        if(som.isPlaying == false){
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

    public void reacao(bool rec){
        /*
            Função receber um sentimento e escolhe aleatoriamente uma frase no banco de frases com o sentimento correspondente
        */

        if (rec == true){
            estadoAtual = ctrArq.pickUpEmocao("Alegre");
        }else{

            int sentimento = (int)Random.Range(1, 3);

            if(sentimento == 1 && rec == false){
                estadoAtual = ctrArq.pickUpEmocao("Triste");
            }

            if(sentimento == 2 && rec == false){
                estadoAtual = ctrArq.pickUpEmocao("Bravo");
            }

            if(sentimento == 3 && rec == false){
                estadoAtual = ctrArq.pickUpEmocao("Vergonha");
            }
        }

        setConf(estadoAtual);

        startAnimation();
    }

    public void gerarDicaCorreta(){
        int dica1, dica2;

        for(int i=0;i<tabuleiro.Length;i++){
            dica1 = tabuleiro[i];

            if(dica1 != -1){
                for(int j=i+1;j<tabuleiro.Length;j++){
                    dica2 = tabuleiro[j];

                    if(dica1 == dica2){
                        this.dica1 = i+1;
                        this.dica2 = j+1;
                        falarDica();
                        return;
                    }
                }
            }
        }
    }

    public void gerarDicaFalsa(){
        int escolha1 = (int)Random.Range(0.0F, tabuleiro.Length);
        int escolha2 = escolha1;
        while(escolha1 == escolha2){
            escolha2 = (int)Random.Range(0.0F, tabuleiro.Length);
        }

        dica1 = escolha1;
        dica2 = escolha2;
        falarDica();
    }

    private void falarDica(){

        estadoAtual = ctrArq.getFrases("2");

        estadoAtual.msg = estadoAtual.msg+ " " +dica1.ToString()+ " e a "+ dica2.ToString()+ ".";
        Debug.Log(estadoAtual.msg);

        setConf(estadoAtual);
        Speek();
    }
}