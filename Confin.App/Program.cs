using System;
using Confin.Domain.Interfaces.Services;
using Confin.Service.Services;

namespace Confin.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlanejamentoService service = new PlanejamentoService();
            service.GerarPlanejamento();
        }
    }
}