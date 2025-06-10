using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace AppCasier
{
    public class Lecteur
    {

        private string m_tag = ""; // Tag lu par le lecteur
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
            // Vérifier si le port est déjà ouvert
            if (!m_SPort.IsOpen)
            {
                m_SPort.Open();
            }
            
        }
        public void ClosePort()
        {
            // Vérifier si le port est ouvert avant de le fermer
            if (!m_SPort.IsOpen)
            {
                return; // Ne rien faire si le port n'est pas ouvert
            }
            m_SPort.DataReceived -= eventDeLecture; // Détacher l'événement de lecture
            m_SPort.Dispose(); // Libérer les ressources du port série
            m_SPort.Close();
        }

        private void eventDeLecture(object sender, SerialDataReceivedEventArgs e)
        {
            OpenPort();
            Task.Delay(1000).Wait(); // Attendre 2
            m_data = m_SPort.ReadExisting();
            // Afficher la variable m_SPort.DataReceived pour débogage
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
                //Verifier si l'exeption est levée
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

        public bool IsConnected()
        {
            try
            {
                OpenPort(); // Ouvrir le port série
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de connexion au lecteur : " + ex.Message);
                return false;
            }
        }
    }
}