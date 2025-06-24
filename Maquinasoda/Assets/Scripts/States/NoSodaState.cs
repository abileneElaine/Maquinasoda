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
        machine.UpdateStockVisual(); // Remove todas as latinhas visuais
    }

    public void Exit() { }

    public void InsertCoin() { }

    public void Cancel() { }

    public void Order() { }

    public void ToggleMaintenance()
    {
        machine.SetState(machine.GetMaintenanceState());
    }
}