﻿using Preparcial.Controlador;
using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Correccion: indentación del archivo

namespace Preparcial.Vista
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/UCA.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            ActualizarControlers();
        }

        private void ActualizarControlers()
        {
            comboBox1.ValueMember = "Contrasena";
            comboBox1.DataSource = ControladorUsuario.GetUsuarios();
            comboBox1.DisplayMember = "NombreUsuario";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Equals(comboBox1.SelectedValue.ToString()))
            {       
                var obtenerUsuario = (Usuario)comboBox1.SelectedItem;

                ControladorUsuario.ActualizarContrasena(obtenerUsuario.IdUsuario,
                                    txtNewPassword.Text);
                
                //Correccion: actualizar controles después de cambiar de contrasena
                ActualizarControlers();
            }
            else
                MessageBox.Show("Contrasena actual incorrecta");
        }
    }
}
