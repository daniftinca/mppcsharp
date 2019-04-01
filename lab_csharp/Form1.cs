using lab_c.Repository;
using lab_csharp.controller;
using lab_csharp.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using lab_c.Model;

namespace lab_csharp
{
    public partial class Form1 : Form
    {
        Thread thread;
        private LoginController loginController;
        private ParticipantController participantController;
        private ProbaController probaController;
        private ScorController scorController;
        private LoginService loginService;
        public static string username;


        public Form1()
        {
            InitializeComponent();
            
    }

        public Form1(LoginController loginController, ParticipantController participantController, ProbaController probaController, ScorController scorController)
        {
            this.loginController = loginController;
            this.participantController = participantController;
            this.probaController = probaController;
            this.scorController = scorController;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            

            username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
           
            UserRepository arbitruRepository = new UserRepository();
            loginService = new LoginService(arbitruRepository);
            loginController = new LoginController(loginService);
            bool isValid = loginController.loginUser(username, password);
            if (isValid) {
                this.Close();
                thread = new Thread(openNewForm);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

            }

        }

        

        private void openNewForm(object obj) {
            Application.Run(new Form2());
        }





    }
}
