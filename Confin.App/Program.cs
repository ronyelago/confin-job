using System;
using Confin.Data;
using Confin.Data.Interfaces;
using Confin.Data.Repositories;
using Confin.Domain.Entities;

namespace Confin.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IContaRepository contaRepository = new ContaRepository(new DbSession());
            var contas = contaRepository.GetAllActive().Result;

            
        }
    }
}