using System.ComponentModel.DataAnnotations.Schema;

namespace MauiTs.Repository.Entities;

public class Atividade
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateOnly Data { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Materia { get; set; } = string.Empty;
}
