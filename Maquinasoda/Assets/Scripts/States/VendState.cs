using UnityEngine;

public class VendState : IMachineState
{
    private SodaMachine machine;

    public VendState(SodaMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        machine.displayText.text = "Entregando...";
        machine.Dispense();
    }

    public void Exit()
    {
        machine.displayText.text = "";
    }

    public void InsertCoin() { }
    public void Cancel() { }
    public void Order() { }
    public void ToggleMaintenance() { }
}
