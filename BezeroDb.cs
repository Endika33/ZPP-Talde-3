using Oracle.ManagedDataAccess.Client;

namespace ErronkaT3
{
    public static class BezeroDb
    {
        private const string Konexioa =
            "User Id=EUSKANP;Password=1234;Data Source=localhost:1521/XEPDB1";

        public static List<BezeroDatuak> Kargatu()
        {
            var lista = new List<BezeroDatuak>();
            using var kon = new OracleConnection(Konexioa);
            kon.Open();
            using var cmd = new OracleCommand(
                "SELECT ID, IZENA, ABIZENAK, EMAILA, TELEFONOA, OSTATU_MOTA, SORTZE_EGUNA FROM BEZEROAK ORDER BY ID", kon);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new BezeroDatuak
                {
                    Id = Convert.ToInt32(rd["ID"]),
                    Izena = rd["IZENA"]?.ToString() ?? "",
                    Abizenak = rd["ABIZENAK"]?.ToString() ?? "",
                    Emaila = rd["EMAILA"]?.ToString() ?? "",
                    Telefonoa = rd["TELEFONOA"]?.ToString() ?? "",
                    ostatuMota = rd["OSTATU_MOTA"]?.ToString() ?? "",
                    sortzeEguna = rd["SORTZE_EGUNA"] == DBNull.Value
                        ? ""
                        : Convert.ToDateTime(rd["SORTZE_EGUNA"]).ToString("yyyy-MM-dd")
                });
            }
            return lista;
        }

        public static int Gehitu(BezeroDatuak b)
        {
            using var kon = new OracleConnection(Konexioa);
            kon.Open();

            using var idCmd = new OracleCommand("SELECT NVL(MAX(ID), 0) + 1 FROM BEZEROAK", kon);
            int id = Convert.ToInt32(idCmd.ExecuteScalar());

            using var cmd = new OracleCommand(
                "INSERT INTO BEZEROAK (ID, IZENA, ABIZENAK, EMAILA, TELEFONOA, OSTATU_MOTA, SORTZE_EGUNA) " +
                "VALUES (:id, :izena, :abizenak, :emaila, :telefonoa, :ostatuMota, SYSDATE)", kon);

            cmd.BindByName = true;
            cmd.Parameters.Add("id", id);
            cmd.Parameters.Add("izena", b.Izena);
            cmd.Parameters.Add("abizenak", b.Abizenak);
            cmd.Parameters.Add("emaila", b.Emaila);
            cmd.Parameters.Add("telefonoa", b.Telefonoa);
            cmd.Parameters.Add("ostatuMota", b.ostatuMota);

            cmd.ExecuteNonQuery();

            b.Id = id;
            b.sortzeEguna = DateTime.Now.ToString("yyyy-MM-dd");
            return id;
        }
    }
}