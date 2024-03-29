using System;
using System.Data.SqlClient;

public class Cliente
{
    public int IdCliente { get; set; }
    public string TipoIdentificacion { get; set; }
    public string Identificacion { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Sexo { get; set; }
    public int Edad { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaVencimientoIdentificacion { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Provincia { get; set; }
    public string Canton { get; set; }
    public string Distrito { get; set; }
    public string Pais { get; set; }
}

public class Usuario
{
    public string Cedula { get; set; }
    public string Contraseña { get; set; }
    public string CorreoElectronico { get; set; }
    public string Perfil { get; set; }
}

public class ServicioAdicional
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }
}

public class ConexionBD
{
    private string connectionString;

    public ConexionBD(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool ValidarCredenciales(string cedula, string contraseña, string perfil)
    {
        string query = "SELECT COUNT(*) FROM Usuarios WHERE Cedula = @Cedula AND Contraseña = @Contraseña AND Perfil = @Perfil";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Cedula", cedula);
            command.Parameters.AddWithValue("@Contraseña", contraseña);
            command.Parameters.AddWithValue("@Perfil", perfil);

            connection.Open();
            int count = (int)command.ExecuteScalar();

            return count > 0;
        }
    }

    //  consulta y operacines 
}

public class Menu
{
    public static void MostrarMenu(string perfil)
    {
        Console.WriteLine("---- Menú de opciones ----");

        switch (perfil)
        {
            case "Administrador":
                Console.WriteLine("1. Registro de clientes");
                Console.WriteLine("2. Reservaciones");
                Console.WriteLine("3. Facturación");
                break;

            case "Recepcionista":
                Console.WriteLine("1. Reservaciones");
                break;

            case "Cajera":
                Console.WriteLine("1. Facturación");
                break;

            case "Cliente":
                Console.WriteLine("1. Realizar reservación");
                Console.WriteLine("2. Ver historial de reservaciones");
                break;

            default:
                Console.WriteLine("Perfil no reconocido. No se pueden mostrar opciones.");
                break;
        }

        Console.WriteLine("0. Salir");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ejemplo de uso
        string perfilUsuario = "Administrador";
        Menu.MostrarMenu(perfilUsuario);
    }
}
