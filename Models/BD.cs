namespace TP6_JJOO_Entenza_Jolodovsky_Kovadloff.Models;
using System.Data.SqlClient;
using Dapper;
public static class BD{
    private static string _connectionString = @"Server = A-PHZ2-LUM-08;DataBase = JJOO;Trusted_Connection=True;";

    public static void AgregarDeportista(Deportista dep){
        string sql= "INSERT INTO Deportistas (Apellido, Nombre, Foto, IdPais, IdDeporte, FechaNacimiento) VALUES (@aApellido, @nNombre, @fFoto, @iIdPais, @iIdDeporte, @fFechaNacimiento )";
        using(SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new {aApellido=dep.Apellido, nNombre = dep.Nombre, fFoto = dep.Foto, fFechaNacimiento = dep.FechaNacimiento, iIdPais=dep.IdPais, iIdDeporte=dep.IdDeporte });
        }
    }
    public static void EliminarDeportista(int idDeportista){
        string sql ="DELETE FROM Deportistas where IdDeportista = @deportistista";
        using(SqlConnection db= new SqlConnection(_connectionString)){
            db.Execute(sql, new {deportistista=idDeportista});
        }
    }
    public static Deporte? VerInfoDeporte(int idDeporte){
        Deporte? MiDeporte=null;
        using(SqlConnection db= new SqlConnection(_connectionString)){
            string sql="SELECT * from Deportes where IdDeporte=@deportete";
            MiDeporte=db.QueryFirstOrDefault<Deporte>(sql, new {deportete = idDeporte});
        }
        return MiDeporte;
    }
     public static Pais? VerInfoPais(int idPais){
        Pais? MiPais=null;
        using(SqlConnection db= new SqlConnection(_connectionString)){
            string sql="SELECT * from Paises where IdPais=@paisis";
            MiPais=db.QueryFirstOrDefault<Pais>(sql, new {paisis = idPais});
        }
        return MiPais;
    }
    public static Deportista? VerInfoDeportista(int idDeportista){
        Deportista? MiDeportista = null;
        using(SqlConnection db= new SqlConnection(_connectionString)){
            string sql="SELECT * from Deportistas where IdDeportista=@deportistata";
            MiDeportista=db.QueryFirstOrDefault<Deportista>(sql, new {deportistata = idDeportista});
        }
        return MiDeportista;
    }
    public static List<Pais> ListarPaises(){
        List<Pais> _ListadoPaises=new List<Pais>();
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * from Paises";
            _ListadoPaises=db.Query<Pais>(sql).ToList();
        }
        return _ListadoPaises;
    }
    public static List<Deporte> ListarDeportes(){
        List<Deporte> _ListadoDeportes=new List<Deporte>();
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * from Deportes";
            _ListadoDeportes=db.Query<Deporte>(sql).ToList();
        }
        return _ListadoDeportes;
    }
     public static List<Deportista> ListarDeportistasDeporte(int idDeporte){
        List<Deportista> _ListadoDeportistas=new List<Deportista>();
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * from Deportistas where IdDeporte=@depepep";
            _ListadoDeportistas=db.Query<Deportista>(sql, new{depepep = idDeporte}).ToList();
        }
        return _ListadoDeportistas;
    }
    public static List<Deportista> ListarDeportistasPais(int idPais){
        List<Deportista> _ListadoDeportistas=new List<Deportista>();
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * from Deportistas where IdPais=@paisisis";
            _ListadoDeportistas=db.Query<Deportista>(sql, new{paisisis = idPais}).ToList();
        }
        return _ListadoDeportistas;
    }
}