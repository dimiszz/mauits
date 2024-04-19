using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MauiTs.Items;

public class Materia
{
    public string Nome { get; set; } = string.Empty;
    public string ACH {  get; set; } = string.Empty;
    public List<string> Horarios { get; set; } = [];
    public List<string> Salas { get; set; } = [];
    public string Dia {  get; set; } = string.Empty;
}
