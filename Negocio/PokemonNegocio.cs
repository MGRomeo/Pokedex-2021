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
            SqlDataReader lector;
            try
            {
                Conexion.ConnectionString = "data source = DESKTOP-BGQHSHU\\SQLEXPRESS; initial catalog = POKEDEX_DB; integrated security = true";
                Comando.CommandType = System.Data.CommandType.Text;
                //Comando.CommandText = "select nombre, descripcion ,numero, UrlImagen from POKEMONS";
                Comando.CommandText = "select nombre, p.Descripcion, Numero, UrlImagen, t.Descripcion as Tipo, d.Descripcion as Debilidad from POKEMONS p, ELEMENTOS t, ELEMENTOS d where IdTipo = t.Id and IdDebilidad = d.Id";
                Comando.Connection = Conexion;

                Conexion.Open();
                lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Nombre = lector.GetString(0);
                    aux.Descripcion = lector.GetString(1);
                    aux.Numero = lector.GetInt32(2);
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["tipo"];
                    //aux.Debilidad.Descripcion = (string)lector["debilidad"];
                    
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
                Comando.Connection = Conexion;
                Comando.CommandText = "insert into POKEMONS values (" + pokemon.Numero + ",'" + pokemon.Nombre + "', '" + pokemon.Descripcion + "', '" + pokemon.UrlImagen + "',@idTipo, @idDebilidad, null,1)";
                Comando.Parameters.AddWithValue("@idTipo", pokemon.Tipo.Id);
                Comando.Parameters.AddWithValue("@idDebilidad", pokemon.Debilidad.Id);

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
  