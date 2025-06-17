using UnityEngine;

public class HasCoinState : IMachineState
{
    private SodaMachine machine;

    public HasCoinState(SodaMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        machine.displayText.text = "OK";
    }

    public void Exit()
    {
        machine.displayText.text = "";
    }

    public void InsertCoin() { }

    public void Cancel()
    {
        machine.SetState(machine.GetNoCoinState());
    }

    public void Order()
    {
        machine.SetState(machine.GetVendState());
    }

    public void ToggleMaintenance() { }
}

