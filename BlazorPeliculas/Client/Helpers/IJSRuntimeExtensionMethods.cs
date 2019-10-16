using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        // Funcion de JavaSctipt que devuelve algo (en este caso el valor true/false del cuadro de confirmaicón que muestra la funcion confirm de javascript)
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("confirm", mensaje);
        }

        // Funcion de Javascript que NO devuelve nada (la fución console.write, por ejemplo, no devuelve nada en javascript)
        public static async ValueTask ConsoleWrite(this IJSRuntime js, string mensaje)
        {
            await js.InvokeVoidAsync("console.log", mensaje);
        }
    }
}
