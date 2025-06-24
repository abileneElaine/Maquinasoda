public class NoCoinState : IMachineState
{
    private SodaMachine machine;

    public NoCoinState(SodaMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        machine.displayText.text = "Insira uma moeda";
    }

    public void Exit() { }

    public void InsertCoin()
    {
        machine.SetState(machine.GetHasCoinState());
    }

    public void Cancel() { }

    public void Order() { }

    public void ToggleMaintenance()
    {
        machine.SetState(machine.GetMaintenanceState());
    }
}