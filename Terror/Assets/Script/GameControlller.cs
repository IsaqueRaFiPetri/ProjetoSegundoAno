using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum GameState //pode colocar qualquer numero, O numero vai gerar automaticamente acrescentando +1
{
    Play, Pause
}*/
public class GameControlller : MonoBehaviour
{
    public static GameControlller instance;
    //public GameState gameState;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        //int teste = (int)gameState;
        //gameState = (GameState)teste;
    }

    
    void Update()
    {
        /*switch (GameControlller.instance.gameState) //o SWITCH nasceu para trabalhar com a Maquina de E  stado
        {
            case GameState.Play:
                agent.SetDestination(PlayerInteraction.instance.transform.position);
                break;
            case GameState.Pause:

                break;
        }*/
    }
}
//alguma variavel dentro de um parentese = cast, que traduz de uma variavel para outra
