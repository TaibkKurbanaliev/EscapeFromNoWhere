using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpellCaster _caster;

    private void Awake()
    {
        _playerMovement.Initialize();
        _caster.Initialize();
    }
}
