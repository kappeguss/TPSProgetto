namespace QuizSceltaMultipla_Mazzoleni
{
    public partial class Form1 : Form
    {
        private int indiceDomandaCorrente = 0;
        private int punteggioGiocatore1 = 0;
        private int punteggioGiocatore2 = 0;
        private bool turnoGiocatore1 = true;
        private List<Domanda> domande;
        private int timer;
        private const int limiteTempoDomanda = 30;
        private System.Windows.Forms.Timer countdownTimer;  // Specifica esplicitamente il Timer di Windows Forms

        public Form1()
        {
            InitializeComponent();
            CaricaDomande();

            // Inizializzazione del timer
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // intervallo di 1 secondo
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void CaricaDomande()
        {
            domande = new List<Domanda>
            {
                new Domanda("Qual è la capitale della Francia?", new[] {"Parigi", "Londra", "Roma", "Berlino"}, 0),
                new Domanda("Quanto fa 2 + 2?", new[] {"3", "4", "5", "6"}, 1),
                new Domanda("Qual è il colore del cielo?", new[] {"Rosso", "Verde", "Blu", "Giallo"}, 2),
                new Domanda("Qual è l'unica squadra italiana", new[] {"Burgio", "Nighiri", "Pompini", "Roma"}, 3)
            };
        }

        private void IniziaQuiz()
        {
            // Mostra la prima domanda
            MostraDomanda(domande[indiceDomandaCorrente]);
            AvviaTimer();
        }

        private void AvviaTimer()
        {
            // Imposta il tempo e avvia il timer
            timer = limiteTempoDomanda;
            countdownTimer.Start();
            AggiornaTimer(timer);
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timer--;
            AggiornaTimer(timer);
            if (timer <= 0)
            {
                countdownTimer.Stop();
                PassaTurno();
            }
        }

        private void AggiornaTimer(int tempo)
        {
            // Aggiorna la label con il tempo rimanente
            lblTimer.Text = $"Tempo rimasto: {tempo}s";
        }

        private void MostraDomanda(Domanda domanda)
        {
            // Mostra la domanda e le opzioni sui bottoni
            lblDomanda.Text = domanda.Testo;
            btnOpzione1.Text = domanda.Opzioni[0];
            btnOpzione2.Text = domanda.Opzioni[1];
            btnOpzione3.Text = domanda.Opzioni[2];
            btnOpzione4.Text = domanda.Opzioni[3];
        }

        private void PassaTurno()
        {
            // Se il tempo è scaduto o la risposta è errata, passa al prossimo giocatore
            if (turnoGiocatore1)
            {
                turnoGiocatore1 = false;
                MessageBox.Show("Passa al Giocatore 2.");
            }
            else
            {
                turnoGiocatore1 = true;
                MessageBox.Show("Passa al Giocatore 1.");
            }

            // Carica la domanda successiva o mostra il punteggio finale
            if (indiceDomandaCorrente < domande.Count - 1)
            {
                indiceDomandaCorrente++;
                MostraDomanda(domande[indiceDomandaCorrente]);
                AvviaTimer();
            }
            else
            {
                MostraPunteggioFinale();
            }
        }

        private void MostraPunteggioFinale()
        {
            // Mostra i punteggi finali
            MessageBox.Show($"Punteggio Giocatore 1: {punteggioGiocatore1}\nPunteggio Giocatore 2: {punteggioGiocatore2}", "Quiz Completato");
        }

        private void btnOpzione1_Click(object sender, EventArgs e)
        {
            ControllaRisposta(0);  // Controlla la risposta per la prima opzione
        }

        private void btnOpzione2_Click(object sender, EventArgs e)
        {
            ControllaRisposta(1);  // Controlla la risposta per la seconda opzione
        }

        private void btnOpzione3_Click(object sender, EventArgs e)
        {
            ControllaRisposta(2);  // Controlla la risposta per la terza opzione
        }

        private void btnOpzione4_Click(object sender, EventArgs e)
        {
            ControllaRisposta(3);  // Controlla la risposta per la quarta opzione
        }

        private void ControllaRisposta(int scelta)
        {
            // Verifica se la risposta è corretta
            if (scelta == domande[indiceDomandaCorrente].IndiceRispostaCorretta)
            {
                // Risposta corretta
                if (turnoGiocatore1)
                {
                    punteggioGiocatore1++;
                }
                else
                {
                    punteggioGiocatore2++;
                }
                MessageBox.Show("Risposta Esatta!");
            }
            else
            {
                // Risposta errata
                MessageBox.Show("Risposta Errata!");
            }

            // Ferma il timer e passa al turno successivo
            countdownTimer.Stop();
            PassaTurno();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Avvia il quiz al caricamento del form
            IniziaQuiz();
        }
    }
}
