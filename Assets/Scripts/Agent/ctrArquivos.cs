using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Arquivos{

    List<Frase> frases;
    string id;
    public string filePath = Application.persistentDataPath;

    public Arquivos(string id){
        frases = new List<Frase>();
        this.id = id;
        criarArquivo();
        lerFrases();
    }

    public void criarArquivo(){ 
        /*
            Criar o arquivo de saida para o individo
        */
        string cabecalho;

        // C:/Users/007br/Documents/TCC/UnityEmotionalAgent/EmotionalAgent/Assets/Scripts
        using(StreamWriter file = File.CreateText(filePath + "/individo" + id + ".txt")){
                cabecalho = "EmoçãoClasse;Código;Frase";
                file.WriteLine(cabecalho);
            }
        return;
    }

    public void lerFrases(){
        /*
            Função responsavel por ler o arquivo de frases e adicionar na lista frases
        */
        string line;
        string[] vetorline;

         
        System.IO.StreamReader file = 
            new System.IO.StreamReader(filePath + "/falas.txt");
        

        while( (line = file.ReadLine()) != null){ // Ler linha por linha do arquivo de entrada falas.txt
            Frase novo = new Frase();

            vetorline = line.Split(';');
            novo.codigo = vetorline[0];
            novo.emocao = vetorline[1];
            novo.msg = vetorline[2];
            frases.Add(novo);
        }

        file.Close();
    }

    public void registra(string msg, string cod, string emocao){
        /*
            Função responsavel por receber os dados e gravalos no arquivo de saida
        */
        using(var file = new StreamWriter(filePath + "/individo" + id + ".txt", true)){
                file.WriteLine(emocao + ";" + cod + ";" + msg + ";");
            }
    }

    public Frase getFrases(string cod){
        /*
            é informado o codigo, e a função retorna o objeto, caso não ache retorna um valor nulo
        */
        Frase f = new Frase();

        foreach(Frase frase in frases){
            if(frase.codigo.Equals(cod)){
                f = frase;
                return f;
            }
        }

        return null;
    }

}

public class Frase{
    public string codigo;    // Guarda o identificador da frase
    public string emocao;    // Guarda o amoção que será exibida
    public string msg;       // Garda a menssagem ou frase
}
