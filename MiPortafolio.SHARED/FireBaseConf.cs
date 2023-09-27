
using Microsoft.Extensions.Configuration;
using MiPortafolio.ENT;
using Newtonsoft.Json;

namespace MiPortafolio.SHARED
{
    public class FireBaseConf
    {
        public static string CrearConfiguracionDB(IConfigurationRoot configuration)
        {
            FireBaseConfig fireBaseConfig = new FireBaseConfig
            {
                type = configuration.GetSection("FirebaseConfig")["type"],
                project_id = configuration.GetSection("FirebaseConfig")["project_id"],
                private_key_id = configuration.GetSection("FirebaseConfig")["private_key_id"],
                private_key = configuration.GetSection("FirebaseConfig")["private_key"],
                client_email = configuration.GetSection("FirebaseConfig")["client_email"],
                client_id = configuration.GetSection("FirebaseConfig")["client_id"],
                auth_uri = configuration.GetSection("FirebaseConfig")["auth_uri"],
                token_uri = configuration.GetSection("FirebaseConfig")["token_uri"],
                auth_provider_x509_cert_url = configuration.GetSection("FirebaseConfig")["auth_provider_x509_cert_url"],
                client_x509_cert_url = configuration.GetSection("FirebaseConfig")["client_x509_cert_url"],
                universe_domain = configuration.GetSection("FirebaseConfig")["universe_domain"]

            };

            string direcctorio = string.Concat(Environment.CurrentDirectory, "\\ArchivosTemp\\firebase-adminsdk.json");

            using (StreamWriter write = new StreamWriter(direcctorio))
            {
                write.WriteLine(JsonConvert.SerializeObject(fireBaseConfig));
            }
            return direcctorio;
        }
    }
}
