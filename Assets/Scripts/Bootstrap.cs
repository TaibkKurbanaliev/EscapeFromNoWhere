using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpellCaster _caster;
    [SerializeField] private Seller _seller;

    private void Awake()
    {
        _playerMovement.Initialize();
        _caster.Initialize();
        _seller.Initialize();
    }
}
