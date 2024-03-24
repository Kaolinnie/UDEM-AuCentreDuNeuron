using UnityEngine.Localization;

public class LanguageManager {
    public Locale locale;
    public static LanguageManager Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }
}
