using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelo;
using negocio;

namespace Pokedex
{
    public partial class frmPokemon : Form
    {
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                nuevo.Numero = (int)numeroPokemon.Value;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.UrlImagen = (string)txtUrl.Text;

                negocio.Agregar(nuevo);
                MessageBox.Show("Pokemon agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
