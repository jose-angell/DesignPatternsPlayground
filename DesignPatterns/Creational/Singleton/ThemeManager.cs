

namespace DesignPatterns.Creational.Singleton;

//Un Theme Manager es una clase que controla cómo se ve la interfaz de
//usuario (UI) de una aplicación: colores, fuentes, modo oscuro/claro, etc.
public sealed class ThemeManager {

    // Campo estático para la instancia única (singleton)
    private static ThemeManager? _instance;
    
    // Objeto para bloquear acceso concurrente (thread-safe)
    private static readonly object _lock = new();

    // Constructor privado: impide instanciación directa
    private ThemeManager(){
        // Valores por defecto
        IsDarkMode = false;
        PrimaryColor = "Blue";
        FontSize = 14;
    }

    public static ThemeManager Instance {
        get {
            lock(_lock){
                _instance ??= new ThemeManager();
                return _instance;
            }
        }
    }

    // Propiedades del tema
    public bool IsDarkMode { get; private set; }
    public string PrimaryColor { get; private set; }
    public int FontSize { get; private set; }

    // Métodos para cambiar temas
    public void ApplyDarkTheme()
    {
        IsDarkMode = true;
        PrimaryColor = "DarkGray";
        FontSize = 16;
    }

    public void ApplyLightTheme()
    {
        IsDarkMode = false;
        PrimaryColor = "LightBlue";
        FontSize = 14;
    }

    public void SetCustomTheme(string color, int fontSize, bool darkMode)
    {
        PrimaryColor = color;
        FontSize = fontSize;
        IsDarkMode = darkMode;
    }
}