namespace QuizSceltaMultipla_Mazzoleni
{
    public partial class Form1 : Form
    {
        private int indiceDomanda = 0;
        private int punteggioGiocatore1 = 0;
        private int punteggioGiocatore2 = 0;
        private bool turnoGiocatore = true;
        private List<Domanda> domande;
        private int timer;
        private const int limiteTempoDomanda = 30;
        private System.Windows.Forms.Timer countdownTimer;  // Specifica esplicitamente il Timer di Windows Forms
        private int indiceRispostaCorrettaAttuale; // Traccia quale bottone contiene la risposta corretta

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
                new Domanda("Qual è la capitale del Canada?", new[] {"Otranto", "Londra", "Ottawa", "Baku"}, 2),
                new Domanda("Qual è l'algoritmo che viene impiegato dai sistemi operativi per assegnare \nla risorsa tempo di esecuzione CPU ai processi?", new[] { "Quicksort", "Dijkstra", "Bubble Sort", "Round Robin"}, 3),
                new Domanda("Qual è il componente del pc dotato di memoria volatile ?", new[] {"SSD", "RAM", "CPU", "Hard Disk"}, 1),
                new Domanda("Quali sono le cellule che vanno ad intervenire per ULTIME \ne ad arrestare la perdita di sangue?", new[] {"Globuli Rossi", "Globuli Bianchi", "Piastrine", "Neuroni"}, 2),
                new Domanda("Chi ha scritto la 'Divina Commedia'?", new[] {"Dante Alighieri", "Shakespeare", "Petrarca", "Boccaccio"}, 0),
                new Domanda("Qual è il metallo più leggero?", new[] {"Alluminio", "Litio", "Ferro", "Argento"}, 1),
                new Domanda("Quando è stato incoronato Carlo Magno?", new[] {"800 a.c.", "25 dicembre 900 d.c.", "814 d.c.", "800 d.c."}, 3),
                new Domanda("Qual'è il Pallone d'oro 2007?", new[] {"Messi", "Emilio Butragueno", "Kaka", "R9"}, 2),
                new Domanda("Qual'è il primo linguaggio informatico \ncreato nella storia?", new[] {"Short code", "Assembly", "C", "Phyton"}, 0),
                new Domanda("Dato l'anagramma della parola 'PALEOCAPA', \ncosa utilizzeresti per trovare tutte le combinazioni?", new[] {"Permutazioni", "Disposizioni REP", "Combinazioni","Permutazioni REP"}, 3)
            };
        }

        private void IniziaQuiz()
        {
            // Mostra la prima domanda
            MostraDomanda(domande[indiceDomanda]);
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
            // Mostra la domanda
            lblDomanda.Text = domanda.Testo;

            // Assegna le opzioni ai bottoni in ordine
            btnOpzione1.Text = domanda.Opzioni[0];
            btnOpzione2.Text = domanda.Opzioni[1];
            btnOpzione3.Text = domanda.Opzioni[2];
            btnOpzione4.Text = domanda.Opzioni[3];

            // Salva l'indice della risposta corretta
            indiceRispostaCorrettaAttuale = domanda.IndiceRispostaCorretta;
        }

        private void PassaTurno()
        {
            // Se il tempo è scaduto o la risposta è errata, passa al prossimo giocatore
            if (turnoGiocatore)
            {
                turnoGiocatore = false;
                MessageBox.Show("Passa al Giocatore 2.");
            }
            else
            {
                turnoGiocatore = true;
                MessageBox.Show("Passa al Giocatore 1.");
            }

            // Carica la domanda successiva o mostra il punteggio finale
            if (indiceDomanda < domande.Count - 1)
            {
                indiceDomanda++;
                MostraDomanda(domande[indiceDomanda]);
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
            if (scelta == indiceRispostaCorrettaAttuale)
            {
                // Risposta corretta
                if (turnoGiocatore)
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
