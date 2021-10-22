using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[Serializable]
public class EntradaTexto
{
    public String palavra;

    [SerializeField]
    public string[] palavrasCertas = new string[] { "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez" };
    [SerializeField]
    public string[] palavrasErradas = new string[] {"Verde", "Azul", "Amarelo", "Vermelho", "Branco", "Preto", "Cinza", "Laranja", "Roxo", "Rosa" };

    public String patch = "Assets/Palavras";
    public void Save()
    {
        var content = JsonUtility.ToJson(this);
        File.WriteAllText(patch, content);
    }
}
