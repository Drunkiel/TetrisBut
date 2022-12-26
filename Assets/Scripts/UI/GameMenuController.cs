using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject menuUI;

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
    }

    public void FallButton()
    {
        BlockMovement _blockMovement = GameObject.FindGameObjectWithTag("FallingBlock").GetComponent<BlockMovement>();

        if (_blockMovement.cooldown > _blockMovement.timeToStop)
        {
            _blockMovement.cooldown = _blockMovement.timeToStop;
        }
    }

    public void SettingsMenuButton()
    {
        isMenuOpen = !isMenuOpen;

        menuUI.SetActive(isMenuOpen);
    }
}
