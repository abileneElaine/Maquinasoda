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
        machine.UpdateStockVisual();
    }

    public void Exit() { }

    public void InsertCoin()
    {
        machine.stock++;
        machine.UpdateStockVisual(); // Adiciona visual da latinha
    }

    public void Cancel() { }

    public void Order() { }

    public void ToggleMaintenance()
    {
        if (machine.stock <= 0)
            machine.SetState(machine.GetNoSodaState());
        else
            machine.SetState(machine.GetNoCoinState());
    }
}