using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using log.Models;

namespace PrimerProyecto.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=Login+Registro;Trusted_Connection=True;";
        
       public static Login LoginIngresado(string Usuario, string Contraseña)
    {
        Login Ingresado = new Login();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Usuario WHERE Usuario= @pUsuario and Contraseña= @pContraseña";
            Ingresado = db.QueryFirstOrDefault<Login>(SQL, new { pUsuario= Usuario , pContraseña = Contraseña });
        }
        return Ingresado;
    }
       public static Login ListarPorId(int id)
    {
        Login Ingresado = new Login();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Usuario WHERE id= @pid";
            Ingresado = db.QueryFirstOrDefault<Login>(SQL, new { pid= id });
        }
        return Ingresado;
    }
    public static void InsertUser(Login user)
{
    string SQL = "INSERT INTO Usuario(Usuario, Contraseña, Nombre, Email, Telefono)";
    SQL += " VALUES (@pUsuario, @pContraseña, @pNombre, @pEmail, @pTelefono)";

    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL, new
        {
            pUsuario = user.Usuario,
            pContraseña = user.Contraseña,
            pNombre = user.Nombre,
            pEmail = user.Email,
            pTelefono = user.Telefono
        });
    }
    }
    public static void ActualizarContraseña(string Usuario, string NuevaContraseña)
{
    string SQL = "Update Usuario Set Contraseña = @pNuevaContraseña where Usuario=@pNuevoUsuario";

    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL, new
        {
            pNuevaContraseña = NuevaContraseña,
            pNuevoUsuario = Usuario
        });
    }
    }
    }
    }