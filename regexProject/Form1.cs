using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace regexProject
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //Inicialización de estado de contraseña
        private void txtpassword_Enter(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        // -> Funciones Regex
        private bool regexNombre()
        {
            Regex er = new Regex("^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[ ]*)+$");
            bool ok = false;

            if (er.IsMatch(txtName.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
                
            }
            return ok;
        }

        private bool regexDireccion()
        {
            bool ok = false;
            Regex er = new Regex("^[a-záéíóúA-Z-0-9 .,/]{15,100}$");

            if(er.IsMatch(txtAddress.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        private bool regexPassword ()
        {
            bool ok = false;
            Regex er = new Regex("^(?=.{8,15}$)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*).*$");

            if(er.IsMatch(txtpassword.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        private bool regexCorreo ()
        {
            bool ok = false;
            Regex er = new Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
            if(er.IsMatch(txtEmail.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;

        }
        
        private bool regexFecha()
        {
            Regex er = new Regex("([1-9]|[1-2][0-9]|[3][0-1])[-/]([0][1-9]|[1][0-2])[-/]([2][0][0][0-9]|[2][0][1][0 - 9]|[2][0][2][0-9])");
   
            bool ok = false;
            if (er.IsMatch(txtDate.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        private bool regexCodigoPostal()
        {
            Regex er = new Regex("^([0-2][0-9][0][0-9][0-9])$");
            bool ok = false;
            if (er.IsMatch(txtCodigo.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        private bool regexSexo()
        {
         Regex er = new Regex("^([M|m]{1}[asculino]{8})|([F|f]{1}[emenino]{7})$");
                bool ok = false;
         if (er.IsMatch(txtSexo.Text))
        {
         ok = true;
        }
         else
        {
         ok = false;
        }
        return ok;
        }

        private bool regexDpi ()
        {
            bool ok = false;
            Regex er = new Regex("^[0-9]{13}$");
            if (er.IsMatch(txtDpi.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;

            }

            return ok;
        }

        private bool regexNit()
        {
            Regex er = new Regex("^([0-9]{8})$|^([0-9]{8}[A-Z]{1})$");
            bool ok = false;
            if (er.IsMatch(txtNit.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        private bool regexNumero()
        {
            bool ok = false;
            Regex er = new Regex("^([0-9]{8})$");

            if (er.IsMatch(txtNumero.Text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        // -> Botón validar
        private void btnValidate_Click(object sender, EventArgs e)
        {

            // En caso de que estén vacíos
            if (txtName.Text == "" && txtAddress.Text == "" && txtEmail.Text == "" &&
                txtpassword.Text == "" && txtDpi.Text == ""  && txtNit.Text == "" &&
                txtCodigo.Text == "" && txtNumero.Text == "" && 
                txtSexo.SelectedIndex == -1) 
            {
                MessageBox.Show("Los campos se encuentran vacíos", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // En caso de que algún campo este vacío

            if(txtName.Text == "")
            {
                MessageBox.Show("El campo Nombre se encuentra vacío",
               "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regexNombre() == false)
            {
            MessageBox.Show("Nombre no válido, inicial mayúscula sin números y sin simbolos verificar!",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtAddress.Text == "")
            {
                MessageBox.Show("El campo Dirección se encuentra vacío",
               "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regexDireccion() == false)
            {
                MessageBox.Show("Dirección no válida, no debe llevar símbolos y debe ser mayor de 10 caracteres y menor a 100... verificar!",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtEmail.Text == "")
            {
                MessageBox.Show("El campo Correo se encuentra vacío",
                "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
            else if (regexCorreo() == false)
            {
                MessageBox.Show("Correo electrónico no válido, debe tener un @ y un dominio... verificar!",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtpassword.Text == "")
            {
                MessageBox.Show("El campo Contraseña se encuentra vacío",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regexPassword() == false)
            {
                MessageBox.Show("Contraseña no válida, debe contener al menos una letra mayúscula ,una minuscula, números y algun simbolo, la longitud mayor a 8 caracteres y menor a 15... verificar!",
            
               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(regexFecha() == false)
            {
                MessageBox.Show("Fecha no válida, debe verificar entre rango de 01/01/2000 - 01-01-2022... verificar!",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (regexSexo() == false)
            {
                MessageBox.Show("Sexo no válido, seleccione Masculino o Femenino... verificar!",
               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtDpi.Text == "")
            {
                MessageBox.Show("El campo DPI se encuentra vacío",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regexDpi() == false)
            {
                MessageBox.Show("DPI no válido (solo números), sin espacios, letras o simbolos... verificar!", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtNit.Text == "")
            {
                MessageBox.Show("El campo NIT se encuentra vacío",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regexNit() == false)
            {
                MessageBox.Show("Nit no válido (solo números), sin simbolos ni espacios... verificar!", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(txtCodigo.Text == "")
            {
                MessageBox.Show("El campo Código se encuentra vacío",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(regexCodigoPostal() == false)
            {
                MessageBox.Show("Código postal no válido (Solo números), no mayor a 5 dígitos", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            if(txtNumero.Text == "")
            {
                MessageBox.Show("El campo Número se encuentra vacío",
                    "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if(regexNumero() == false)
            {
                MessageBox.Show("Número debe ser de 8 dígitos, sin espacios... verificar!",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(regexNombre() && regexDireccion() && regexPassword() 
               && regexFecha() && regexSexo() && regexCorreo() && regexDpi() && regexNit()
               && regexCodigoPostal() && regexNumero() == true)
            {
                MessageBox.Show("Datos ingresados Correctamente", "Aceptación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               MessageBox.Show("Campos incorrectos", "Error", 
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


   
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        // -> Validaciones (evento textChanged y errorProvider)
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            if (regexNombre() == false)
            {
                errorProvider1.SetError(txtName, "Nombre no válido, inicial mayúscula sin números ni símbolos");
            }
            else if (regexNombre() == true)
            {
                //Borra el mensaje de error cuando haya cumplido con la expresión
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            
            if(regexDireccion() == false)
            {
                errorProvider2.SetError(txtAddress, "No debe contener simbolos y debe ser mayor de 10 caracteres y menor a 100");
            } else {
                errorProvider2.SetError(txtAddress, "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if(regexCorreo() == false)
            {
                errorProvider3.SetError(txtEmail, "Debe contener un @ y un dominio");
            }
            else
            {
                errorProvider3.SetError(txtEmail, "");
            }
        }
        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if(regexPassword() == false)
            {
                errorProvider4.SetError(txtpassword, "Debe contener almenos una letra mayúscula, una minuscula, números y algun simbolo (entre 8 y 15 caracteres)");

            } // debe ter
            else
            {
                errorProvider4.SetError(txtpassword, "");
            }
        }

        private void txtDate_TabIndexChanged(object sender, EventArgs e)
        {
            if(regexFecha() == false)
            {
                errorProvider5.SetError(txtDate, "Debe verificar entre rango de 01/01/2000 - 01-01-2023");
            }
            else
            {
                errorProvider5.SetError(txtDate, "");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (regexSexo() == false)
            {
                errorProvider6.SetError(txtSexo, "Click en la pestaña para elegir una opción válida");
            }
            else
            {
                errorProvider6.SetError(txtSexo, "");
            }
        }

        private void txtDpi_TextChanged(object sender, EventArgs e)
        {
            if(regexDpi() == false)
            {
                errorProvider7.SetError(txtDpi, "Sólo se permiten números sin espacios, letras o símbolos (deben ser 13 dígitos)");
            }
            else
            {
                errorProvider7.SetError(txtDpi, "");
            }
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {
            if(regexNit() == false)
            {
                errorProvider8.SetError(txtNit, "Sólo se permiten números, sin espacios, letras o símbolos (deben ser 8 dígitos)");
            }
            else
            {
                errorProvider8.SetError(txtNit, "");
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if(regexCodigoPostal() == false)
            {
                errorProvider9.SetError(txtCodigo, "Sólo se permiten números (deben ser 5 dígitos)");
            }
            else
            {
                errorProvider9.SetError(txtCodigo, "");

            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if(regexNumero() == false)
            {
                errorProvider10.SetError(txtNumero, "Sólo se permiten números (deben ser 8 dígitos)");
            }
            else
            {
                errorProvider10.SetError(txtNumero, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Checkbox para la contraseña
        private void chbxPassword_CheckedChanged(object sender, EventArgs e)
        {
            
            if(chbxPassword.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;
                //txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
