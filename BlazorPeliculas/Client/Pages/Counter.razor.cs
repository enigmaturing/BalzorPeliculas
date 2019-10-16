using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        [Inject] protected IJSRuntime JS { get; set; }

        protected int currentCount = 0;
        static int currentCountStatic = 0;

        protected async Task IncrementCount()
        {
            currentCount++;
            Singleton.Valor = currentCount;
            Transient.Valor = currentCount;
            currentCountStatic++;
            // Video 30: Para probar a llamar un méotodo de C# desde Javascript, primero llamo desde C# a una funcion de 
            // JS que he definido en root/js/Utilidades, llamada "pruebaPuntoNetStatic" esta función a su vez llamará 
            // al método de C# "ObtenerCurrentCount"
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }

        // El siguiente, es el método estático al que llamamos desde una funcion de JS en el video 30 de la seccion 3
        // Como se llama desde JS, se ha de usar la directiva [JSInvokable]
        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
