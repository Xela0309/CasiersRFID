using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace AppCasier
{
    public class Lecteur
    {

        private string m_tag = "";
        private string m_data = "";
        private string m_port;
        private int m_baud;
        private SerialPort m_SPort;


        public Lecteur(string port, int baud)
        {
            m_port = port;
            m_baud = baud;
            m_SPort = new SerialPort(m_port, m_baud, Parity.None, 8, StopBits.One);
        }
        
        public void OpenPort()
        {
            m_SPort.Open();
        }
        public void ClosePort()
        {
            m_SPort.DataReceived -= eventDeLecture; // Détacher l'événement de lecture
            m_SPort.Dispose(); // Libérer les ressources du port série
            m_SPort.Close();
        }

        private void eventDeLecture(object sender, SerialDataReceivedEventArgs e)
        {
            Task.Delay(2000).Wait(); // Attendre 2
            m_data = m_SPort.ReadExisting();

            if (m_data.Length == 14)
            {
                m_tag = ""; // Réinitialiser le tag
                for (int i = 1; i < m_data.Length - 1; i++)
                {
                    m_tag += m_data[i]; // ajouter le caractère au tag
                }
            }
        }

        public string GetTag()
        {
            return m_tag;
        }

        public void SetTag(string tag)
        {
            m_tag = tag;
        }
        public bool lireTag()
        {
            int time = 0;
            while (m_tag == "")
            {
                m_SPort.DataReceived += eventDeLecture;
                Task.Delay(50).Wait(); // Attendre 50ms
                time += 50;
                if (time >= 5000) // Si le temps d'attente dépasse 5 secondes
                {
                    m_SPort.DataReceived -= eventDeLecture; // Détacher l'événement de lecture
                    return false; // Retourner false si aucun tag n'est lu
                }
            }
            return true; // Retourner true si un tag est lu
        }

    }
}
