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

    public void Exit() { }

    public void InsertCoin() { }

    public void Cancel()
    {
        machine.SetState(machine.GetNoCoinState());
    }

    public void Order()
    {
        if (machine.stock > 0)
        {
            machine.stock--;
            machine.UpdateStockVisual(); // Remove uma latinha visual
            machine.SetState(machine.GetVendState());
        }
        else
        {
            machine.SetState(machine.GetNoSodaState());
        }
    }

    public void ToggleMaintenance()
    {
        machine.SetState(machine.GetMaintenanceState());
    }
}