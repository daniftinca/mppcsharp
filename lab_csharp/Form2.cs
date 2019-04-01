using lab_c.Model;
using lab_c.Repository;
using lab_csharp.controller;
using lab_csharp.repository;
using lab_csharp.service;
using lab_csharp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_csharp
{
    public partial class Form2 : Form
    {
        private LoginController loginController;
        private ParticipantController participantController;
        private ProbaController probaController;
        private ScorController scorController;
        User arbitru;
        Proba selectedProba;



        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridViewParticipantiScoruri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        /// <summary>
        /// Selecteaza o proba din combobox si afiseaza scorurile in tabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxProbe_SelectedIndexChanged(object sender, EventArgs e)
        {
            showScoruriForProba();
        }

        /// <summary>
        /// Afiseaza scorurile in tabel
        /// </summary>
        private void showScoruriForProba() {
            Proba proba = (Proba)comboBoxProbe.SelectedItem;
            ScorRepository scorRepository = new ScorRepository();
            ScorService scorService = new ScorService(scorRepository);
            scorController = new ScorController(scorService);
            List<Scor> listaScoruri = scorController.getScoruriFromProba(proba);
            var bindingList = new BindingList<Scor>(listaScoruri);
            var source = new BindingSource(bindingList, null);
            dataGridViewParticipantiScoruri.DataSource = source;

        }

        /// <summary>
        /// Afiseaza probele in combobox
        /// </summary>
        public void fillProbeComboBox() {
            ProbaRepository probaRepository = new ProbaRepository();
            ProbaService probaService = new ProbaService(probaRepository);
            probaController = new ProbaController(probaService);
            List<Proba> listaProbe = probaController.findAll();
            

            foreach (Proba elem in listaProbe)
            {
                comboBoxProbe.DisplayMember = elem.Name;
                comboBoxProbe.ValueMember = elem.Id.ToString();
                comboBoxProbe.Items.Add(elem);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            LoginService loginService = new LoginService(userRepository);

            loginController = new LoginController(loginService);
            arbitru = loginController.findByUsername(Form1.username);

            fillProbeComboBox();
            selectedProba = probaController.findAllForArbitru(arbitru)[0];

            showParticipantiFaraNotaLaProba();
            
            showTableNrTotalPuncte();

            fillProbeCombo();
            

        }


        private void fillProbeCombo()
        {
            List<Proba> listaProbe = probaController.findAllForArbitru(arbitru);
            foreach (Proba elem in listaProbe)
            {
                comboBox1.DisplayMember = elem.Name.ToString();
                comboBox1.ValueMember = elem.Id.ToString();
                comboBox1.Items.Add(elem);
            }
        }

        /// <summary>
        /// Afiseaza participantii fara nota la o proba in combobox
        /// </summary>
        public void showParticipantiFaraNotaLaProba() {

            UserRepository arbitruRepository = new UserRepository();
            LoginService arbitruService = new LoginService(arbitruRepository);
            loginController = new LoginController(arbitruService);
            arbitru = loginController.findByUsername(Form1.username);
            //Console.WriteLine(Form1.username);     

            ParticipantRepository participantRepository = new ParticipantRepository();
            ParticipantService participantService = new ParticipantService(participantRepository);
            participantController = new ParticipantController(participantService);
            List<Participant> listaParticipanti = participantController.getParticipantWithNoScoreForProba(selectedProba);

            comboBoxParticipanti.Items.Clear();
            foreach (Participant elem in listaParticipanti)
            {
                comboBoxParticipanti.DisplayMember = elem.Name.ToString();
                comboBoxParticipanti.ValueMember = elem.Id.ToString();
                comboBoxParticipanti.Items.Add(elem);
            }
        }

    
        public List<ScoreTotal> getNrTotalPuncte() {
            ScorRepository scorRepository = new ScorRepository();
            ScorService scorService = new ScorService(scorRepository);
            scorController = new ScorController(scorService);
            return scorController.getNrTotalDePuncte();
        }

        /// <summary>
        /// Afiseaza participantii si numarul total de puncte obtinut de fiecare participant
        /// </summary>
        public void showTableNrTotalPuncte() {

            List<ScoreTotal> totalPuncteList = getNrTotalPuncte();
            var bindingList = new BindingList<ScoreTotal>(totalPuncteList);
            var source = new BindingSource(bindingList, null);
            dataGridViewParticipantiScoruri.DataSource = source;
            
        }

        /// <summary>
        /// Adauga nota pentru un participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNota_Click(object sender, EventArgs e)
        {
            int nota = Convert.ToInt32(textBoxNota.Text);
            Participant participant = (Participant)comboBoxParticipanti.SelectedItem;
            Console.Write(participant);
            ScorRepository scorRepository = new ScorRepository();
            ScorService scorService = new ScorService(scorRepository);
            scorController = new ScorController(scorService);
            Proba proba = selectedProba;
            Scor scor = new Scor(participant, proba, nota);
            scorController.save(scor);
            showTableNrTotalPuncte();

        }

        private void textBoxNota_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxParticipanti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Proba proba = (Proba) comboBox1.SelectedItem;
            selectedProba = probaController.findOne(proba.Id);
            showParticipantiFaraNotaLaProba();
        }
    }
}
