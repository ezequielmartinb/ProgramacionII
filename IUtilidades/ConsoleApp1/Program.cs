using ClassLibrary;
using ClassLibrary1;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estacionamiento estacionamiento = new Estacionamiento("Estacionamiento UTN");
            Estacionamiento estacionamiento1 = new Estacionamiento();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Join(path, $"{Path.DirectorySeparatorChar}estacionamiento.json");
            estacionamiento.ListadoDeVehiculos.Add(new Auto("MTP350", "FORD", DateTime.Now, 500, ETipoAuto.Urbano));

            estacionamiento.SerializarEstacionamiento(estacionamiento, path);
            estacionamiento1 = estacionamiento.DeserializarEstacionamiento(path);

          



            //JsonSerializadorYDeseralizador<Estacionamiento> jsonSerializadorYDeseralizador = new JsonSerializadorYDeseralizador<Estacionamiento>();


            //var toJson = JsonConvert.SerializeObject(new Auto("MTP350", "FORD", DateTime.Now, 500, ETipoAuto.Urbano),Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //});
            //var fromJson = JsonConvert.DeserializeObject<Estacionamiento>(toJson, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //});
        }
    }
}
