using System.Collections;
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
        machine.StartCoroutine(EntregarRefri());
    }

    public void Exit() { }

    public void InsertCoin() { }

    public void Cancel() { }

    public void Order() { }

    public void ToggleMaintenance() { }

    private IEnumerator EntregarRefri()
    {
        machine.displayText.text = "Entregando...";
        machine.animator.SetTrigger("dispense");

        yield return new WaitForSeconds(1.5f);

        if (machine.stock <= 0)
            machine.SetState(machine.GetNoSodaState());
        else
            machine.SetState(machine.GetNoCoinState());
    }
}