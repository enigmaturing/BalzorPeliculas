using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Pages
{
    public class CounterBase: ComponentBase
    {
        [Inject] protected ServicioSingleton Singleton { get; set; }
        [Inject] protected ServicioTransient Transient { get; set; }

        protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
            Singleton.Valor = currentCount;
            Transient.Valor = currentCount;
        }
    }
}
