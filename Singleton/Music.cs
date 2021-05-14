using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
class Music : MonoBehaviour {
    private static Music instance = null;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    public int musicToPlay = 0;

    public static Music Instance {
        get {
            if (instance == null) {
                instance = (Music)FindObjectOfType(typeof(Music));
            }
            return instance;
        }
    }

    void Start() {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update() {
        if (audioSource.isPlaying == false) {
            audioSource.clip = clips[musicToPlay];
            audioSource.Play();
        }
    }

    void Awake() {
        if (Instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
}