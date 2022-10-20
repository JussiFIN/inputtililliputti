using UnityEngine;

public class ReadInputs : MonoBehaviour
{
    PlayerInputActionAsset playerinputs;
    
    public float throttleInput;
    public float brakeInput;
    public float turnInput;
    public float positionInput;
    public Vector2 balanceInput;
    public bool standupInput;
    public bool restartInput;
    public bool RespawnInput;
    public bool openMapInput;
    public Vector2 freelookInput;
    //tähän vielä dpad, tutustu miten se pelittää ku Control Type on Dpad input actioneissa

    void OnEnable()
    {
        playerinputs.GamePlay.Enable();
    }

    void OnDisable()
    {
        playerinputs.GamePlay.Disable();
    }

    void Awake()
    {
        playerinputs = new PlayerInputActionAsset();

        playerinputs.GamePlay.Throttle.performed += ctx => throttleInput = ctx.ReadValue<float>();
        playerinputs.GamePlay.Throttle.canceled += ctx => throttleInput = 0f;
        playerinputs.GamePlay.Brake.performed += ctx => brakeInput = ctx.ReadValue<float>();
        playerinputs.GamePlay.Brake.canceled += ctx => brakeInput = 0f;
        playerinputs.GamePlay.Turn.performed += ctx => turnInput = ctx.ReadValue<float>();
        playerinputs.GamePlay.Turn.canceled += ctx => turnInput = 0f;
        playerinputs.GamePlay.Changeposition.performed += ctx => positionInput = ctx.ReadValue<float>();
        playerinputs.GamePlay.Changeposition.canceled += ctx => positionInput = 0f;
        playerinputs.GamePlay.Balance.performed += ctx => balanceInput = ctx.ReadValue<Vector2>();
        playerinputs.GamePlay.Balance.canceled += ctx => balanceInput = Vector2.zero;
        playerinputs.GamePlay.Standup.started += ctx => standupInput = true;
        playerinputs.GamePlay.Standup.canceled += ctx => standupInput = false;
        playerinputs.GamePlay.Restart.canceled += ctx => restartInput = true;
        playerinputs.GamePlay.Respawn.canceled += ctx => RespawnInput = true;
        playerinputs.GamePlay.OpenMap.started += ctx => openMapInput = true;
        playerinputs.Map.CloseMap.started += ctx => openMapInput = false;
    }    
}
