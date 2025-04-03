using System.IO.Ports;


namespace testlecteur
{
    internal class classLecteur
    {
        private string m_tag = "";
        private string m_data = "";
        private string m_port;
        private int m_baud ;
        private SerialPort m_SPort;


        public classLecteur(string port,int baud)
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

        public void lireTag()
        {
            Console.WriteLine(" Port ouvert, en attente de badge...");
            while (m_tag == "")
            {
                m_SPort.DataReceived += eventDeLecture;
            }
        }

    }
}
