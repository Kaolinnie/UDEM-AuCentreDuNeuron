using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    private Mode mode;
    public GameObject alertBox;

    // public GameObject timer;

    public GameObject alert_pain;
    public GameObject alert_sensation;

    public GameObject energy;
    private Energy_Meter em;

    private float energy_val;

    private Alert alert;
    
    private enum Alert {
        pain,
        sensation
    }

    private Stage stage;

    private enum Stage {
        NaStage,
        KStage,
        NaKStage,
        Post
    }
    
    
    
    private void Awake() {
        Instance = this;
        mode = Mode.SingleNeuronGame;
        em = energy.GetComponent<Energy_Meter>();
        energy_val = em.Energy;
        stage = Stage.NaStage;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        createAlert();   
    }

    void createAlert() {
        var ran = Random.Range(1, 3);
        GameObject obj;
        if (ran == 1) {
            alert = Alert.pain;
            obj = Instantiate(alert_pain, alertBox.transform);
        }
        else {
            alert = Alert.sensation;
            obj = Instantiate(alert_sensation, alertBox.transform);
        }

        obj.transform.localScale = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update() {
        energy_val = em.Energy;
        PlayGame();
    }

    void PlayGame() {
        Debug.Log(stage);
        if (alert == Alert.pain) PainPlay();
        if (alert == Alert.sensation) SensationPlay();
    }

    void SensationPlay() {
        if (stage == Stage.NaStage) {
            if ((int) em.SodiumLevel > 108 && (int) em.SodiumLevel < 112) stage = Stage.KStage;
            return;
        }
        if (stage == Stage.KStage) {
            if ((int) em.PotassiumLevel > 123 && (int) em.PotassiumLevel < 127) stage = Stage.NaKStage;
            return;
        }
        if (em.SodiumLevel > 112) LoseGame("Vouz avez trop de sodium, la personne est morte.");
        if(em.PotassiumLevel>127) LoseGame("Vouz avez trop de potassium, le neurone ne fonctionne pas corectement.");
        if (stage == Stage.NaKStage) {
            if ((int) energy_val > -72 && (int) energy_val < -68) stage = Stage.Post;
        }
    }

    void PainPlay() {
        if (stage == Stage.NaStage) {
            if ((int) em.SodiumLevel > 13 && (int) em.SodiumLevel < 17) stage = Stage.KStage;
            if ((int) em.SodiumLevel > 17) LoseGame("Vouz avez trop de sodium, la personne est morte.");
            return;
        }
        if (stage == Stage.KStage) {
            if ((int) em.PotassiumLevel > 28 && (int) em.PotassiumLevel < 32) stage = Stage.NaKStage;
            if((int) em.PotassiumLevel>32) LoseGame("Vouz avez trop de potassium, le neurone ne fonctionne pas corectement.");
            return;
        }
        if (stage == Stage.NaKStage) {
            if ((int) energy_val > -72 && (int) energy_val < -68) stage = Stage.Post;
        }
    }

    public void SendMail() {
        if (stage == Stage.Post) {
            WinGame();
        }
        else {
            LoseGame("Le neurone est incomplet.");
        }
    }

    void LoseGame(string message) {
        WinLose.message = message;
        SceneManager.LoadScene("EndScreen");
    }
    
    void WinGame() {
        WinLose.message = "Vouz gagnez!";
        SceneManager.LoadScene("EndScreen");
    }
}
