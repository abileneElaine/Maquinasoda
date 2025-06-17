using UnityEngine;

public class MaintenanceState : IMachineState
{
    private SodaMachine machine;

    public MaintenanceState(SodaMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        machine.displayText.text = "Modo Manutenção";
    }

    public void Exit()
    {
        machine.displayText.text = "";
    }

    public void InsertCoin()
    {
        machine.stock++;
        machine.UpdateAnimator();
    }

    public void Cancel() { }
    public void Order() { }

    public void ToggleMaintenance()
    {
        if (machine.stock > 0)
            machine.SetState(machine.GetNoCoinState());
        else
            machine.SetState(machine.GetNoSodaState());
    }
}

