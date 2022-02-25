using PlayerController;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class RuneStoneTrigger : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private Player _player;
    [SerializeField] private Objective objective;
    [SerializeField] private GameObject parentGo;
    [SerializeField] private AudioClip textAppearanceSound;
    [SerializeField] private AudioClip disappearingSound;
    [SerializeField] private GameObject disappearingParticles;
    private AudioSource _audioSource;

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        _textMeshPro.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _textMeshPro.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(textAppearanceSound, transform.position);
            player.OnButtonPressed += ActivateRune;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _textMeshPro.gameObject.SetActive(false);
            player.OnButtonPressed -= ActivateRune;
        }
    }

    private void OnDisable()
    {
        try
        {
            _player.OnButtonPressed -= ActivateRune;
        }
        catch
        {
            // ignored
        }

        _textMeshPro.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        AudioSource.Destroy(this);
    }

    private void ActivateRune()
    {
        objective.AddActivatedShrine();
        Destroy(parentGo);
        var position = transform.position;
        AudioSource.PlayClipAtPoint(disappearingSound, position);
        var particles = Instantiate(disappearingParticles, position, quaternion.identity);
        var time = 5f;
        Destroy(particles, time);
    }
}