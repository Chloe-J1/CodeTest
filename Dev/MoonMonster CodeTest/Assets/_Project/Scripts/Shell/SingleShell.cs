using NaughtyAttributes;
using UnityEngine;

public class SingleShell : MonoBehaviour, IShell
{
    [SerializeField] private float _launchForce = 15f;
    private Rigidbody _shell;

    private void Start()
    {
        _shell = GetComponent<Rigidbody>();
    }
    public Collider Fire(Transform spawnTransform)
    {
        Rigidbody shellInstance =
                Instantiate(_shell, spawnTransform.position, spawnTransform.rotation) as Rigidbody;
        
        shellInstance.linearVelocity = _launchForce * spawnTransform.forward;

        Collider collider = shellInstance.GetComponent<Collider>();
        if (collider == null)
        {
            Debug.LogError("ShellInstance has no collider");
            return new Collider();
        }
        return collider;
    }
}
