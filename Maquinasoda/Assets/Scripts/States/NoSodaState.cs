using UnityEngine;

public class NoSodaState : IMachineState
{
    private SodaMachine machine;

    public NoSodaState(SodaMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        machine.displayText.text = "VAZIO";
    }

    public void Exit()
    {
        machine.displayText.text = "";
    }

    public void InsertCoin() { }
    public void Cancel() { }
    public void Order() { }

    public void ToggleMaintenance()
    {
        machine.SetState(machine.GetMaintenanceState());
    }
}
