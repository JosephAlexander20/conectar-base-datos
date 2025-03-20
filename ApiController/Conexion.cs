using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

[ApiController]
[Route("conexion")]
public class Conexion : Controller { 
    
    [HttpGet("sql")]
    public IActionResult ListarCarrerasSql(){
        List<CarreraSQL>lista = new List<CarreraSQL>();
        SqlConnection conn = new SqlConnection (CadenasConexion.SQL_SERVER);
        SqlCommand cmd = new SqlCommand("select IdCarrera, Carrera from Carrera");
        cmd.Connection = conn; 
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            CarreraSQL carrera = new CarreraSQL();
            carrera.IdCarrera = reader.GetInt16("IdCarrera");
            carrera.Carrera = reader.GetString("Carrera");
            lista.Add(carrera);

        }
        reader.Close();
        conn.Close();

        cmd.ExecuteNonQuery();
        return Ok(lista);
    }
    [HttpGet("mongo")]

    public IActionResult ListarSalonesMongoDb(){
        return Ok();
    }

}
