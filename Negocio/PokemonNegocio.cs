using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using modelo;


namespace negocio

{
    public class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> Lista = new List<Pokemon>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader Lector;

            try
            {
                Conexion.ConnectionString = "data source = DESKTOP-BGQHSHU\\SQLEXPRESS; initial catalog = POKEDEX_DB; integrated security = true";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select nombre, descripcion ,numero, UrlImagen  from POKEMONS";
                Comando.Connection = Conexion;

                Conexion.Open();
                Lector = Comando.ExecuteReader();

                while (Lector.Read())
                {
                    Pokemon aux = new Pokemon
                    {
                        Nombre = Lector.GetString(0),
                        Descripcion = Lector.GetString(1),
                        Numero = Lector.GetInt32(2),
                        UrlImagen = (string)Lector["UrlImagen"]
                    };

                    Lista.Add(aux);

                }

                Conexion.Close();
                return Lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Agregar(Pokemon pokemon)
        {
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            try
            {
                Conexion.ConnectionString = "data source = DESKTOP-BGQHSHU\\SQLEXPRESS; database = POKEDEX_DB; integrated security = true";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "insert into POKEMONS values (" + pokemon.Numero + ",'" + pokemon.Nombre + "', '" + pokemon.Descripcion + "', '" + pokemon.UrlImagen + "',1,1,null,1)";
                Comando.Connection = Conexion;

                Conexion.Open();
                Comando.ExecuteNonQuery();
                            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
