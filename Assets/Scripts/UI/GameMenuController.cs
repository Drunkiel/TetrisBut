using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject menuUI;

    public Button[] buttons;

    void Update()
    {
        if (GameController.isGameRunning && !PlayerController.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateButton();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                FallButton();
            }
        }
    }

    public void ReadyButton()
    {
        buttons[0].interactable = false;

        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().RunGame();
    }

    public void RotateButton()
    {
        GameObject block = GameObject.FindGameObjectWithTag("FallingBlock");

        if (block.TryGetComponent<BlockRotation>(out BlockRotation _blockRotation))
        {
            _blockRotation.RotateBlock();
        }
        else if (block.TryGetComponent<NonStandardBlockRotation>(out NonStandardBlockRotation _nonStandardBlockRotation))
        {
            _nonStandardBlockRotation.RotateBlock();
        }
        else return;
    }

    public void FallButton()
    {
        GameObject block = GameObject.FindGameObjectWithTag("FallingBlock");
        BlockMovement _blockMovement = block.GetComponent<BlockMovement>();

        if (_blockMovement.cooldown > _blockMovement.timeToStop)
        {
            _blockMovement.cooldown = _blockMovement.timeToStop;
        }

        if (block.TryGetComponent<BlockRotation>(out BlockRotation _blockRotation))
        {
            Destroy(_blockRotation);
        }
        else if (block.TryGetComponent<NonStandardBlockRotation>(out NonStandardBlockRotation _nonStandardBlockRotation))
        {
            Destroy(_nonStandardBlockRotation);
        }
        else return;
    }

    public void SettingsMenuButton()
    {
        isMenuOpen = !isMenuOpen;

        menuUI.SetActive(isMenuOpen);
    }
}
