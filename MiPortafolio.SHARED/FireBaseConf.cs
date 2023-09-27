
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MiPortafolio.ENT;
using Newtonsoft.Json;

namespace MiPortafolio.SHARED
{
    public class FireBaseConf
    {
        public static string CrearConfiguracionDB()
        {
            FireBaseConfig fireBaseConfig = new FireBaseConfig
            {
                type = "service_account",
                project_id = "miportafolio-279f1",
                private_key_id = "dc00b29a5d9aa98ac8ab4f7dfe8b83227daf6330",
                private_key = "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC0FRmT+rglW2JS\nd5+2Ikgh26x1tk6mShWBbnuBXsywqjaX7ExbktMS4YGuaIlB5nYcY8UkNwKMUYAh\nABa0a9lSlMZQWmFiCwb+heDdDGIq4pMX6sRRzkzGbi2Sg1zb4OWMLgFn7hbgTHJb\nV2u3077mDNECFSsMJU7PAqJFcG33KHp7c3gxK54g6JJObEFl3XnhxJNIuNU80PZ1\nwd1EFL0RPErG8r/adRKNo6nL8NiGvtzYr5JBy5fFi27BIYmnp7iEYqHtWoCr6Rx5\nYa99LpzDG2bJOf+9aNB0KZX9+GFAXwpcfVFJ7EwVpqr3jYPiRtx8VtmYNf4+0kQY\nELGa4tFBAgMBAAECggEADronhXk0eFSjA7bF/FONJdy028sRH0sRe2xtRAkcUQnY\njV/dJkOJiMKhtAFXUUj/SYbUw2eOySosofZDhRWJWDYzyjQ8ANRBSg0plLZLrHFr\nYWI5FC4cjAFMb44X6OD5cNd91LGtVAJYe1UYyXezBdYQPTz9MGD4MxiGbAqb6aGW\nFRUAXWHnJq/oEyG2HukBaqSbmiy3i8bMrWuenGbgJKF24tPft5ijX8e+S6PtY6H2\nh9hluVhtMNypnJgV/i8HSFhF26apg69YEylVORBis+wLoz0d2ovWSDH4+kJOvwg2\n4rhvujKbgmqde7uQHLiiQOy4mABiQ0UgQYkK2YVpmQKBgQDYJ94fckHSN2ZZS/yR\nZqg9SZWdk7AgCeBYXOgFqq2Z4qp0vKkq4HGWmqdeuf46KRu9uN95XcDptG65fkC6\nN3azD2RGVCI04y2xGjk/Q5izX9vPdK1jm3Y/DhYPzS7i4YE6l6rl0P5zGNj1zyH2\nf649DJJ3VAdbyBkeSbOiuuCJCQKBgQDVRvm7ewh1suYs5j3VSIO3VI28nvs9VxTH\nC27Oa+PQCp2iFRHeUgtqHO3aUMb9goZCDiY/y5vjbIjUjwLo96sprjZ9RrGapQp1\nEti5koMS39kmuUdLDO2RHdgYyvIIlbzjSivOwzFjgm5KdAXwzi4Vz+4nLtOWuWho\nDcTEMTCseQKBgQCaXDYafMyWY2uan1H5P7crNS47/mjLKGJml8o1qcIZX63ceZHR\nBcD4DO8zDV2IiSy/WpN0J0iJXImpu4hbsxn4Gyi/tHtNC2Lo01JIZGxaxDzDtI3R\n0QYrV1LX6+3spZ9UiVTIk2vyI69kMowNbPavsBe0UXSDzaxqXbWDozKPiQKBgA42\nJ4ftn9ev7xSI1w/yQAykTrmF4nno5pKI2X5ZxBlly7E0NDebQfV1LghBH7Fe1DFs\nnfHcUGvsHIYFbY02i6pAWJMqdcU3QCYi9lwPPjqwvdiNuglvOBlWYsLsKwqVZ7vB\ngn/Jk+3skArYBllQc9OyQk1MGn9NpX5hhH4KRRMJAoGBAIwJP0gqBcRmKjVIQZ3Y\nCkxfpu/rDxW4DCWiZgauqbteVq/ccj7JrH0K2ehN7V9Bb0pCLgeNQSPh+CzBxhjD\nsY5biqtRydhsRF0vsL+dH9NvaQN4+ALf0Ij8qOLWt40/Bv1XKQ/Rsxd+g1jILq4r\nb7ThrJ+ysO6JbPlptcfgkAiw\n-----END PRIVATE KEY-----\n",
                client_email = "firebase-adminsdk-khgkr@miportafolio-279f1.iam.gserviceaccount.com",
                client_id = "114592702500875947850",
                auth_uri = "https://accounts.google.com/o/oauth2/auth",
                token_uri = "https://oauth2.googleapis.com/token",
                auth_provider_x509_cert_url = "https://www.googleapis.com/oauth2/v1/certs",
                client_x509_cert_url = "https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-khgkr%40miportafolio-279f1.iam.gserviceaccount.com",
                universe_domain = "googleapis.com"

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
