namespace DesignPatterns.Behavioral.Observer;
// Clase que representa una noticia. Será enviada por la agencia a todos los suscriptores.
// Incluye título, contenido y categoría de la noticia.
public class News
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
}