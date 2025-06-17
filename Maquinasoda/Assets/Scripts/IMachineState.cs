using UnityEngine;

public interface IMachineState
{
    void Enter();   // Ações ao entrar no estado
    void Exit();    // Ações ao sair do estado
    void InsertCoin();
    void Cancel();
    void Order();
    void ToggleMaintenance();
}

