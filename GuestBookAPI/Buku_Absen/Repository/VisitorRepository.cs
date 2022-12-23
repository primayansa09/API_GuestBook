using Buku_Absen.Context;
using Buku_Absen.Model;
using Buku_Absen.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Buku_Absen.Repository.Data
{
    public class VisitorRepository : IRepository
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;
        public VisitorRepository(IConfiguration configuration, MyContext myContext)
        {
            _configuration = configuration;
            this.myContext = myContext;
        }

        DynamicParameters parameters = new DynamicParameters();
         
        public int Insert(Visitor visitor)
        {
            
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API_BukuAbsen"]))
            {
                
                var spInsertData = "SP_Visitors_Insert";
                parameters.Add("@Nama", visitor.Nama);
                parameters.Add("@No_Hp", visitor.No_hp);
                parameters.Add("@Email", visitor.Email);
                parameters.Add("@Alamat", visitor.Alamat);
                parameters.Add("@Provinsi", visitor.Provinsi);
                parameters.Add("@Kota_Kabupaten", visitor.Kota_Kabupaten);
                parameters.Add("@Kecamatan", visitor.Kecamatan);
                parameters.Add("@Kelurahan", visitor.Kelurahan);
                parameters.Add("@KodePos", visitor.KodePos);
                parameters.Add("@Kehadiran", DateTime.Now);
                var insert = connection.Execute(spInsertData, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }


        }
        public int Delete(int key)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API_BukuAbsen"]))
            {
                var spDelete = "SP_Visitors_Delete";
                parameters.Add("@Id", key);
                var delete = connection.Execute(spDelete, parameters, commandType: CommandType.StoredProcedure);
                return delete;
            }
        }

        public IEnumerable<Visitor> Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API_BukuAbsen"]))
            {
                var spAllData = "SP_Visitors_Get";
                var bukuAbsen = connection.Query<Visitor>(spAllData, commandType: CommandType.StoredProcedure);
                return bukuAbsen;
            }
        }

        public Visitor Get(int key)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API_BukuAbsen"]))
            {
                var spGetId = "SP_Visitors_GetId";
                parameters.Add("@Id", key);
                var getId = connection.QuerySingleOrDefault<Visitor>(spGetId, parameters, commandType: CommandType.StoredProcedure);
                return getId;
            }
        }

        public int update(Visitor visitor, int key)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API_BukuAbsen"]))
            {
                var spUpdate = "SP_Visitors_Update";
                parameters.Add("@Id", visitor.Id);
                parameters.Add("@Nama", visitor.Nama);
                parameters.Add("@No_Hp", visitor.No_hp);
                parameters.Add("@Email", visitor.Email);
                parameters.Add("@Alamat", visitor.Alamat);
                parameters.Add("@Provinsi", visitor.Provinsi);
                parameters.Add("@Kota_Kabupaten", visitor.Kota_Kabupaten);
                parameters.Add("@Kecamatan", visitor.Kecamatan);
                parameters.Add("@Kelurahan", visitor.Kelurahan);
                parameters.Add("@KodePos", visitor.KodePos);
                parameters.Add("@Kehadiran", DateTime.Now);
                var update = connection.Execute(spUpdate, parameters, commandType: CommandType.StoredProcedure);
                return update;
            }
        }
    }
}
