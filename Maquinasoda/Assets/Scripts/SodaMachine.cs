using UnityEngine;
using UnityEngine.UI;

public class SodaMachine : MonoBehaviour
{
    public Button insertButton;
    public Button cancelButton;
    public Button orderButton;
    public Button maintenanceButton;
    public Text displayText;
    public Transform stockPanel; // onde ficam os ícones das latas

    public Animator animator;

    [HideInInspector] public int stock = 0;

    private IMachineState currentState;

    // Estados
    private IMachineState manutencaoState;
    private IMachineState semRefrigeranteState;
    private IMachineState semMoedaState;
    private IMachineState comMoedaState;
    private IMachineState vendaState;

    void Start()
    {
        // Cria instâncias dos estados
        manutencaoState = new MaintenanceState(this);
        semRefrigeranteState = new NoSodaState(this);
        semMoedaState = new NoCoinState(this);
        comMoedaState = new HasCoinState(this);
        vendaState = new VendState(this);

        SetState(manutencaoState); // Começa em modo manutenção

        // Liga os botões
        insertButton.onClick.AddListener(() => currentState.InsertCoin());
        cancelButton.onClick.AddListener(() => currentState.Cancel());
        orderButton.onClick.AddListener(() => currentState.Order());
        maintenanceButton.onClick.AddListener(() => currentState.ToggleMaintenance());

        UpdateAnimator();
    }

    public void SetState(IMachineState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();

        UpdateAnimator();
    }

    public void UpdateAnimator()
    {
        animator.SetBool("isMaintaining", currentState == manutencaoState);
        animator.SetBool("hasCoin", currentState == comMoedaState);
        animator.SetInteger("stock", stock);
    }

    public void Dispense()
    {
        if (stock > 0)
        {
            stock--;
            animator.SetTrigger("dispense");
        }

        // Transição de estado depois da venda
        if (stock <= 0)
            SetState(semRefrigeranteState);
        else
            SetState(semMoedaState);
    }

    // Métodos para usar de dentro dos estados
    public IMachineState GetMaintenanceState() => manutencaoState;
    public IMachineState GetNoSodaState() => semRefrigeranteState;
    public IMachineState GetNoCoinState() => semMoedaState;
    public IMachineState GetHasCoinState() => comMoedaState;
    public IMachineState GetVendState() => vendaState;
}
